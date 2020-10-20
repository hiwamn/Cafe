using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IRegisteredWorkTimeRepository : IRepository<RegisteredWorkTime>
    {
        List<RegisteredWorkTime> GetLastWeekWorkingTime(GetLastWeekWorkingTimeDto dto);
        List<RegisteredWorkTime> GetAdminRegisteredDailyWorkingTime(GetAdminRegisteredDailyWorkingTimeDto dto);
    }
}
