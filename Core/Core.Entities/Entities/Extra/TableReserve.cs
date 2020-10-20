using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class TableReserve : BaseEntity
    {
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }
        public Guid? TableId { get; set; }
        public virtual Table Table { get; set; }
        public long? Time{ get; set; }
        public string Description{ get; set; }
        public int StatusId { get; set; }
        public EntityStatus Status { get; set; }
        public virtual List<Bill> Bill { get; set; }
    }
}
