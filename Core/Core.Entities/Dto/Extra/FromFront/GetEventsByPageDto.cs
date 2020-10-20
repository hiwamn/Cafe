using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetEventsByPageDto : BaseByUserPageDto
    {

    }
    public class GetEventsByPageResultDto : BaseApiPageResult
    {
        public List<EventAndLeagueDto> Object { get; set; }
        public List<RecentEvent> RecentEvent { get; set; }
    }
   
    public class RecentEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Days{ get; set; }
        public long StartTime { get; set; }
    }
}
