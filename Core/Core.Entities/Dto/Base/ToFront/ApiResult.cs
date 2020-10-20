
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class ApiResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }
    }
    public class FixedIntResultDto : BaseApiResult
    {
        public List<FixedIntDto> Object { get; set; }
    }


}
