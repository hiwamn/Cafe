using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetBillsByPageDto : BaseByUserPageDto    
    {

    }
    public class GetBillsByPageResultDto : BaseApiPageResult
    {
        public List<BillDto> Object { get; set; }
    }
}
