using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class CalculatePriceDto
    {
        public Guid BillId{ get; set; }
    }
    public class CalculatePriceResultDto : BaseApiResult
    {
        public int Object { get; set; }
    }

    
}
