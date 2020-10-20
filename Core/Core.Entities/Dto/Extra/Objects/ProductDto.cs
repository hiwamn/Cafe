
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<string> Images { get; set; }
        public List<ProductDto> Children{ get; set; }
        public int StatusId { get; internal set; }
        public FixedGuidDto Parent { get; internal set; }
        public int StaffPrice { get; internal set; }
    }

   
}
