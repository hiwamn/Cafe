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
    public class ChangeUserReserveAccess : IChangeUserReserveAccess
    {

        private readonly IUnitOfWork unit;

        public ChangeUserReserveAccess(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(ChangeUserReserveAccessDto dto)
        {

            BaseApiResult result = new BaseApiResult { Status = true, Message = Messages.Success, };
            
            var user = unit.Users.Get(dto.UserId);
            user.CanReserve = dto.CanReserve;
            unit.Complete();


            return result;
        }
    }
}
