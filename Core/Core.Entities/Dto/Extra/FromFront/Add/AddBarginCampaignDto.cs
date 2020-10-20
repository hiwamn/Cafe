using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddBarginCampaignDto
    {
        public string Name { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public int PaticipantCount { get; set; }
        public int Value { get; set; }
        public int BarginTypeId { get; set; }
        public string Description { get; set; }
        public int? GameTypeId { get; set; }
        public bool? IsProductDiscount { get; set; }
    }
}
