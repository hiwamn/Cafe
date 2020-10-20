using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class RegisterStaff : IRegisterStaff
    {
        private readonly IUnitOfWork unit;

        public RegisterStaff(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(RegisterStaffDto dto)
        {   
            var now = Agent.UnixTimeNow();
            var u = unit.Users.GetByMobile(dto.Mobile);
            if (u == null)
            {
                User user = new User()
                {
                    FamilyName = dto.FamilyName,
                    Name = dto.Name,
                    Mobile = dto.Mobile,
                    CreatedAt = now,
                    Birthday = dto.Birthday,
                    Status = Enums.EntityStatus.Active.ToInt(),
                    UserRole = new List<UserRole> { new UserRole { CreatedAt = now, RoleId = UserType.Staff.ToInt() } }
                };
                unit.Users.Add(user);
            }
            else
            {
                unit.UserRoles.Add(new UserRole { CreatedAt = now, RoleId = UserType.Staff.ToInt(),UserId = u.Id });
            }
            unit.Complete();
            
            return new BaseApiResult {Status = true };
        }
    }
}
