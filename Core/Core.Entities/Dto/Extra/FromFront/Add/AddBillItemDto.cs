using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddBillItemDto
    {
        public Guid BillId { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public string Description { get; set; }
    }
    public class AddBillItemForStaffResultDto : BaseApiResult
    {
        public BillDto Object { get; set; }
    }
}
