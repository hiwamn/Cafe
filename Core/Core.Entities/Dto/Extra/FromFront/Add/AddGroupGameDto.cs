using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddGroupGameDto
    {
        public string Name { get; set; }
        public long StartTime { get; set; }
        public int PaticipantCount { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int GameTypeId { get; set; }
        public int TotalCount { get; set; }
        public Guid AdminId{ get; set; }
        public int? DiscountPrice { get; set; }
    }
}
