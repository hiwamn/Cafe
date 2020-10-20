using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ChangeUserToAccountant : IChangeUserToAccountant
    {

        private readonly IUnitOfWork unit;

        public ChangeUserToAccountant(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(ChangeUserToAccountantDto dto)
        {

            BaseApiResult result = new BaseApiResult { Status = true, Message = Messages.Success, };

            unit.UserRoles.Add(new UserRole { CreatedAt = Agent.Now,RoleId = Roles.Accountant.ToInt(),UserId = dto.UserId});
            unit.Complete();


            return result;
        }
    }
}
