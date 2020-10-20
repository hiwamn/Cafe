using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class LeftEvent : ILeftEvent
    {

        private readonly IUnitOfWork unit;

        public LeftEvent(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(LeftEventDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            EventUsers ev = unit.EventUsers.GetByUserAndEvent(new JoinEventDto { UserId = dto.UserId.Value,EventAndLeagueId = dto.EventAndLeagueId });
            unit.EventUsers.Remove(ev);
            EventAndLeague t = unit.EventAndLeagues.Get(dto.EventAndLeagueId);
            t.RemainedCount--;
            unit.Complete();
            
            return result;
        }
    }
}
