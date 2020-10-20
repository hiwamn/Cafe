using Enums;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class ChangBillStatusDto
    {
        public Guid Id { get; set; }        
        public Guid TableId { get; set; }        
        public BillStatus StatusId { get; set; }
    }

}
