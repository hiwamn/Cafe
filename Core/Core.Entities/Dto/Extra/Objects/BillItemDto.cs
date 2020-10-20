
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class BillItemDto
    {
        public int Count { get; internal set; }
        public long CreatedAt { get; internal set; }
        public string Description { get; internal set; }
        public Guid Id { get; internal set; }
        public int UnitPrice { get; internal set; }
        public ProductDto Product { get; internal set; }
    }


}
