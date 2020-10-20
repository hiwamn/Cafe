using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class TableMessage : BaseEntity
    {
        public Guid? TableId { get; set; }
        public Table Table { get; set; }
        public int Type { get; set; }
        public string Text { get; set; }
    }
}
