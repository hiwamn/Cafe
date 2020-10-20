using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddBillForStaffDto
    {
        public Guid? UserId { get; set; }
        public string Description { get; set; }
    }

    public class AddBillForStaffResultDto : BaseApiResult
    {
        public BillDto Object { get; set; }
    }

}
