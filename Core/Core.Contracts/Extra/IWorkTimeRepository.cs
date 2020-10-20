using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IWorkTimeRepository : IRepository<WorkTime>
    {
        List<WorkTime> GetLastWeekWorkingTime(GetLastWeekWorkingTimeDto dto);
        List<WorkTime> GetDailyWorkingTime(GetDailyWorkingTimeDto dto);
        List<WorkTime> GetAdminDailyWorkingTime(GetAdminDailyWorkingTimeDto dto);
    }
}
