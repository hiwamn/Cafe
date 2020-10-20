
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class BaseApiPageResult
    {
        public bool Status { get; set; }
        public string Message{ get; set; }
        public PageDto Page { get; set; }
    }

   
}
