using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GiveRewardToStaffDto
    {
        public int Amount { get; set; }        
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }

}
