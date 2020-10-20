using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class ReserveATableDto : BaseByUserDto
    {
        public long Time { get; set; }
        public string BarCode{ get; set; }
        public string Description { get; set; }
        public bool IsPromoter{ get; set; }
        public Guid? TableId{ get; set; }
        public int PeopleCount { get; set; }
    }

}
