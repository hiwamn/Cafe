using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GiveDiscountDto
    {
        public Guid UserId { get; set; }
        public long From { get; set; }
        public long To { get; set; }
        public int Percent { get; set; }
    }

}
