using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class RegisteredTable : UserBaseEntity
    {
        public Guid TableId { get; set; }
        public Table Table { get; set; }
        public long FinishedTime { get; set; }
        public List<Bill> Bill { get; set; }
    }
}
