using Core.Contracts;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ChangeUserStatus : IChangeUserStatus
    {
        private readonly IUnitOfWork unit;

        public ChangeUserStatus(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public BaseApiResult Execute(ChangeUserStatusDto dto)
        {
            BaseApiResult result = new BaseApiResult { Message = "کاربر یافت نشد" };

            var user = unit.Users.Get(dto.UserId);
            if (user != null)
            {
                user.Status = dto.UserStatus.ToInt(); 
                unit.Complete();
                result.Status = true;
            }
            return result;
        }
    }
}
