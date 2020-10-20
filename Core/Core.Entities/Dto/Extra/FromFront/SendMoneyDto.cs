using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class SendMoneyDto
    {
        public int Amount { get; set; }
        public Guid? NextUserId { get; set; }
        public Guid UserId { get; set; }
    }

}
