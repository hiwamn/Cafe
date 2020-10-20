using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class BillItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid BillId { get; set; }
        public virtual Bill Bill { get; set; }
        public int Count{ get; set; }
        public int UnitPrice{ get; set; }
        public string Description{ get; set; }
    }
}
