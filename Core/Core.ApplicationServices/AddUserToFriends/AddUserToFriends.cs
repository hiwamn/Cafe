using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddUserToFriends : IAddUserToFriends
    {

        private readonly IUnitOfWork unit;

        public AddUserToFriends(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddUserToFriendsDto dto)
        {
            ApiResult result = new ApiResult { Status = false,Message = Messages.IsUsed, };
            var now = DateTime.Now.ToUnix();
            if (!unit.UserTransactionList.IsExist(dto))
            {
                UserTransactionList utl = new UserTransactionList
                {
                    CreatedAt = now,
                    PartnerId = dto.PartnerId,
                    UserId = dto.UserId
                };
                unit.UserTransactionList.Add(utl);
                unit.Complete();
                result.Object = utl;
                result.Status = true;
            }
            return result;
        }
    }
}
