using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IEventAndLeagueRepository : IRepository<EventAndLeague>
    {
        EventAndLeagueDto GetById(BaseByIdDto dto);
        GetEventsByPageResultDto GetEventsByPage(BaseByUserPageDto dto);
    }
}
