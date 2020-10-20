using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class PayFromWalletDto : PayBillDto
    {
        public int Paid { get; set; }
        public Guid? UserId { get; set; }
    }

}
