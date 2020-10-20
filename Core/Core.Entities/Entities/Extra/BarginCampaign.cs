using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class BarginCampaign : BaseEntity
    {
        public int BarginTypeId { get; set; }
        public BarginType BarginType { get; set; }
        public int? GameTypeId { get; set; }
        public GameType GameType { get; set; }
        public bool? IsProductDiscount { get; set; }
        public int Value { get; set; }
        public int TotalCount { get; set; }
        public int RemainedCount { get; set; }
        public int StatusId { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
        public virtual List<BarginUsers> BarginUsers { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
    }
}
