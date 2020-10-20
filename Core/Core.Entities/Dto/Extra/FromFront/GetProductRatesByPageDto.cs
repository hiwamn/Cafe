using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetProductRatesByPageDto : BaseByUserPageDto    
    {
        public int StatusId { get; set; }        
    }
    public class GetProductRatesByPageResultDto : BaseApiPageResult
    {
        public List<ProductRateDto> Object { get; set; }
    }
}
