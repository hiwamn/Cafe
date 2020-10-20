using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetBillByIdDto : BaseByIdDto
    {
    }
    public class GetBillByIdResultDto : BaseApiResult
    {
        public BillDto Object { get; set; }
    }
}
