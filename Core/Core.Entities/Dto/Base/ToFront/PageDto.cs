
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class PageDto
    {
        public int TotalCount { get; set; }
        public int CurrentCount{ get; set; }
        public int PageNo { get; set; }
        public long TotalPrice { get; set; }
        public long TotalDiscunt { get; set; }
    }
}
