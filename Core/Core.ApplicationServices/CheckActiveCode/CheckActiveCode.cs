using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Utility.Tools.Auth;
using Utility.Tools.General;
using Utility.Tools.Notification;

namespace Core.ApplicationServices
{
    public class CheckActiveCode : ICheckActiveCode
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public CheckActiveCode(IUnitOfWork unit,
            IJwtHandler jwtHandler
            )
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }

        public CheckActiveCodeResultDto Execute(CheckActiveCodeDto dto)
        {
            var now = Agent.UnixTimeNow();
            var Result = new CheckActiveCodeResultDto { Message = Messages.NotOK };
            if (unit.ActiveCode.CheckActiveCode(dto))
            {
                Result.Message = Messages.OK;
                Result.Status = true;
                var user = unit.Users.GetByMobile(dto.Mobile);
                if (user != null)
                {
                    if (user.UserRole.FirstOrDefault(p => p.RoleId == dto.RoleId) == null)
                        return Result;

                    var userDto = DtoBuilder.CreateUserDto(user);
                    userDto.Token = jwtHandler.Create(user.Id);
                    Result.Object = userDto;
                    if (!unit.Device.IsExist(user.Id, dto.PushId))
                    {
                        unit.Device.Add(new Device { PushId = dto.PushId, CreatedAt = now,UserId = user.Id });
                        unit.Complete();
                    }
                }
                else
                {
                    User newUser = new User()
                    {
                        Mobile = dto.Mobile,
                        CreatedAt = now,
                        Device = new List<Device> { new Device { PushId = dto.PushId, CreatedAt = now } },
                        Status = Enums.EntityStatus.Active.ToInt()
                    };
                    unit.Users.Add(newUser);
                    unit.Complete();
                    var userDto = DtoBuilder.CreateUserDto(newUser);
                    userDto.Token = jwtHandler.Create(newUser.Id);
                    Result.Object = userDto;
                }
            }
            return Result;
        }
    }
}
