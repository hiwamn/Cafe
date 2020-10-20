using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddEventAndLeagueDto
    {
        public string Name { get; set; }
        public long StartTime { get; set; }
        public int PaticipantCount { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int GameTypeId { get; set; }
        public bool IsEvent { get; set; }
        public int? DiscountPrice { get; set; }
    }
}
