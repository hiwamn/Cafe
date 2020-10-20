using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class PaySalaryDto
    {
        public Guid UserId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }

}
