using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetLastWeekWorkingTimeDto : BaseByUserDto    
    {

    }
    public class GetLastWeekWorkingTimeResultDto : BaseApiResult
    {
        public List<DailyWorkingTime> Object { get; set; }
    }

    public class DailyWorkingTime
    {
        public long Date { get; set; }
        public double Hour { get; set; }
        public int Status { get; set; }
    }
}
