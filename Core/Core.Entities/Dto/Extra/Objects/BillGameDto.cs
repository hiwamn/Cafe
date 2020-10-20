
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class BillGameDto
    {
        public GameTypeDto GameType { get; set; }        
        public int Count { get; set; }
        public long From { get; set; }
        public long To { get; set; }
        public int UnitPriceFirstHour { get; set; }
        public int UnitPriceOtherHour { get; set; }
        public string Description { get; set; }
    }


}
