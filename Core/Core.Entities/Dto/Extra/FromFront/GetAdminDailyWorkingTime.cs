using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetAdminDailyWorkingTimeDto 
    {
        public long Date { get; set; }
    }
    public class GetAdminDailyWorkingTimeResultDto : BaseApiResult
    {
        public List<AdminWorkingTimeDto> Object { get; set; }
    }

    public class AdminWorkingTimeDto
    {
        public List<WorkingTimeDto> WorkingTime { get; set; }
        public UserShortDto User{ get; set; }        
    }
}
