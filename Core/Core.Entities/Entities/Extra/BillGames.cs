using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class BillGames : BaseEntity
    {
        public int GameTypeId { get; set; }
        public virtual GameType GameType { get; set; }
        public Guid BillId { get; set; }
        public virtual Bill Bill { get; set; }
        public int Count{ get; set; }
        public long From{ get; set; }
        public long To{ get; set; }
        public int UnitPriceFirstHour { get; set; }
        public int UnitPriceOtherHour { get; set; }
        public string Description{ get; set; }
    }
}
