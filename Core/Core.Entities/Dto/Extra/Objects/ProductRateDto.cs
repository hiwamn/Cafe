
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class ProductRateDto
    {                
        public ProductDto Product { get; set; }                        
        public int Rate { get; set; }
        public int StatusId { get; set; }
        public string Comment { get; set; }
        public UserShortDto User { get; internal set; }
        public Guid Id { get; internal set; }
        public List<ProductRateDto> Children { get; internal set; }
    }

   
}
