using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class GroupGame : BaseEntity
    {
        public string Name { get; set; }
        public int GameTypeId { get; set; }
        public GameType GameType { get; set; }
        public long StartAt { get; set; }
        public int TotalCount { get; set; }
        public int RemainedCount { get; set; }
        public string Description{ get; set; }
        public int Price { get; set; }
        public int StatusId { get; set; }
        public EntityStatus Status { get; set; }
        public List<GroupGameUsers> GroupGameUsers { get; set; }
        public int? DiscountPrice { get; set; }
    }
}
