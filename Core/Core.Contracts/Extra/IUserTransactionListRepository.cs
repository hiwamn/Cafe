using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IUserTransactionListRepository : IRepository<UserTransactionList>
    {
        List<UserShortDto> GetUserTransactionPartners(BaseByUserDto dto);
        bool IsExist(AddUserToFriendsDto dto);
    }
}
