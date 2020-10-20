using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetDailyWorkingTimeDto : BaseByUserDto    
    {
        public long Date { get; set; }
    }
    public class GetDailyWorkingTimeResultDto : BaseApiResult
    {
        public List<WorkingTimeDto> Object { get; set; }
    }

    public class WorkingTimeDto
    {
        public bool IsInput { get; set; }
        public long Time { get; set; }        
    }
}
