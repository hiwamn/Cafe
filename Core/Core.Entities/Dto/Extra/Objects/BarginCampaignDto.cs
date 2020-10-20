
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class BarginCampaignDto
    {
        public Guid Id { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public int ParticipantCount { get; set; }
        public int Value { get; set; }
        public BarginTypeDto BarginType{ get; set; }
        public string Description { get; set; }
        public GameTypeDto GameType{ get; set; }
        public bool IsMine { get; set; }
        public bool? IsProductDiscount { get; set; }
        public List<UserDto> Users { get; internal set; }
        public int RemainedCount { get; internal set; }
    }

    public class Bargin
    {
        public int? GameId { get; set; }
        public bool? IsProductDiscount { get; set; }
        public int Value { get; set; }
        public int Type { get; set; }
    }
    public class Discount
    {
        public int Value { get; set; }
    }


}
