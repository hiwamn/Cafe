using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Table : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int No { get; set; }
        public int MaxCount { get; set; }
        public string BarCode { get; set; }
        public int StatusId { get; set; }
        public bool IsForGame { get; set; }
        public virtual List<RegisteredTable> RegisteredTable { get; set; }
        public virtual List<TableReserve> TableReserve{ get; set; }
        public virtual List<TableMessage> TableMessage { get; set; }
    }
}
