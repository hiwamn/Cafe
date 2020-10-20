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
    public class DeleteStaff : IDeleteStaff
    {
        private readonly IUnitOfWork unit;

        public DeleteStaff(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(BaseByUserDto dto)
        {   
            var now = Agent.UnixTimeNow();
            List<UserRole> u = unit.UserRoles.GetByUserId(dto.UserId);
            unit.UserRoles.RemoveRange(u);
            unit.Complete();
            
            return new BaseApiResult {Status = true };
        }
    }
}
