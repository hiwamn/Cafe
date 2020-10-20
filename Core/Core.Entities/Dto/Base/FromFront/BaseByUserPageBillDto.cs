using System;

namespace Core.Entities.Dto
{
    public class BaseByUserPageBillDto : BaseByUserPageDto
    {
        public int? HasUser { get; set; }
        public int HasDiscount { get; set; }
    }
}
