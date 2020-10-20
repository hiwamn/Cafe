
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class EventAndLeagueDto
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public long StartTime { get; set; }
        public int PaticipantCount { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public GameTypeDto GameType { get; set; }
        public int RemainedCount { get; internal set; }
        public List<UserDto> Users { get; set; }
        public bool IsMine{ get; set; }
        public bool IsEvent { get; internal set; }
        public long CreatedAt { get; internal set; }
        public int? DiscountPrice { get; internal set; }
    }

   
}
