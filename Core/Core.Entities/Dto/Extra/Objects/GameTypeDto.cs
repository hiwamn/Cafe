
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GameTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitPriceFirstHour { get; set; }
        public int UnitPriceOtherHour { get; set; }
        public int HourCount { get; internal set; }
    }

   
}
