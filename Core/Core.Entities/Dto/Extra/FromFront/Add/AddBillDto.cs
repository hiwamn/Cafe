using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddBillDto
    {
        public Guid UserId { get; set; }
        public Guid TableId { get; set; }
    }
}
