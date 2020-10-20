using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetAdminRegisteredDailyWorkingTimeDto
    {
        public long Date { get; set; }
    }
    public class GetAdminRegisteredDailyWorkingTimeResultDto : BaseApiResult
    {
        public List<AdminRegisteredWorkingTimeDto> Object { get; set; }
    }

    public class AdminRegisteredWorkingTimeDto
    {
        public Guid Id { get; set; }
        public double Hour{ get; set; }
        public UserShortDto User{ get; set; }        
    }
}
