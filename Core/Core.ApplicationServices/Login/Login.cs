using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class Login : ILogin
    {
        private readonly IUnitOfWork unit;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;

        public Login(IUnitOfWork unit,
            IEncrypter encrypter,
            IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this._encrypter = encrypter;
            this._jwtHandler = jwtHandler;
        }
        public LoginResultDto Execute(LoginDto dto)
        {
            LoginResultDto result = new LoginResultDto();

            User user = unit.Users.GetByMobile(dto.Mobile);
            if (user == null)
                result.Message = Messages.UserNotExist;
            else if (!user.ValidatePassword(dto.Password, _encrypter))
                result.Message = Messages.InvalidPassword;
            else if (user.Status != Enums.EntityStatus.Active.ToInt())
                result.Message = Messages.UserNotActivated;
            else
            {
                result.Object = DtoBuilder.CreateLoginDto(user);
                result.Object.Token = _jwtHandler.Create(user.Id);
                if (!unit.Device.IsExist(user.Id, dto.DeviceId))
                {
                    unit.Device.Add(new Device { PushId = dto.DeviceId, UserId = user.Id, CreatedAt = DateTime.Now.ToUnix() });
                    unit.Complete();
                }
                result.Status = true;

            }

            return result;
        }

    }
}
