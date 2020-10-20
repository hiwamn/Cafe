using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddProductRateDto
    {
        public Guid UserId { get; set; }
        public Guid? ParentId { get; set; }
        public string Comment { get; set; }
        public Guid ProductId { get; set; }
        public int Rate { get; set; }
        public bool IsForAdmin { get; set; }
    }

}
