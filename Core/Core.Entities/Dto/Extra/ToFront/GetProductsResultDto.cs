using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetProductsDto 
    {
        public Guid? ParentId { get; set; }
        public bool IncludeChildren { get; set; }
    }
    public class GetProductsResultDto : BaseApiResult
    {
        public List<ProductDto> Object { get; set; }
    }
}
