
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class TableMessageDto
    {
        public TableDto Table { get; set; }        
        public long Time { get; set; }
        public string Text{ get; set; }
        public int Type { get; internal set; }
    }

   
}
