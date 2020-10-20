using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IEventUsersRepository : IRepository<EventUsers>
    {
        EventUsers GetByUserAndEvent(JoinEventDto dto);
        List<EventUsers> GetEventUsers(Guid id);
    }
}
