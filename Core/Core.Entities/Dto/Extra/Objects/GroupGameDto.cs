
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GroupGameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long StartTime { get; set; }
        public int TotalCount { get; set; }
        public int RemainedCount { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public GameTypeDto GameType { get; set; }
        public List<UserDto> Users{ get; set; }
        public bool IsMine { get; set; }
        public int? DiscountPrice { get; internal set; }
    }

   
}
