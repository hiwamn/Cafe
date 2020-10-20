
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class TableReserveDto
    {
        public TableDto Table { get; set; }
        public UserShortDto User{ get; set; }
        public long Time { get; set; }
        public int Status { get; internal set; }
        public Guid Id { get; internal set; }
    }

   
}
