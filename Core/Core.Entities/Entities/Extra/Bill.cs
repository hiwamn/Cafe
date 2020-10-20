using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class Bill : UserBaseEntity
    {
        public long EndedAt { get; set; }
        public int PeopleCount { get; set; }
        public Guid? TableReserveId { get; set; }
        public virtual TableReserve TableReserve { get; set; }
        public Guid? PromoterId { get; set; }
        public virtual User Promoter { get; set; }
        public int  StatusId{ get; set; }
        public string Description{ get; set; }
        public int Paid{ get; set; }
        public virtual List<BillItem> BillItem { get; set; }
        public long UpdatedAt { get;set; }
        public virtual List<BillGames> BillGames { get; set; }
        public virtual List<BarginUserBills> BarginUserBills { get; set; }
    }
}
