using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetUserActivityDto : BaseByUserDto
    {
    }
    public class GetUserActivityResultDto : BaseApiResult
    {
        public GetUserActivityObject Object { get; set; }
    }

    public class GetUserActivityObject
    {
        public List<long> Activity { get; set; }
        public double TotalHour { get; set; }
        public double TotalGamingHour { get; set; }
        public double TotalBill { get; set; }
    }
}
