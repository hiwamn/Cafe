using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddTableDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int No { get; set; }
        public string BarCode { get; set; }
        public int MaxCount { get; set; }
    }
}
