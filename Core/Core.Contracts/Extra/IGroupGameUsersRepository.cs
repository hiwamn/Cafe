using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IGroupGameUsersRepository : IRepository<GroupGameUsers>
    {
        GroupGameUsers GetByUserAndGame(LeftGroupGameDto dto);
        List<GroupGameUsers> GetGameUsers(Guid id);
    }
}
