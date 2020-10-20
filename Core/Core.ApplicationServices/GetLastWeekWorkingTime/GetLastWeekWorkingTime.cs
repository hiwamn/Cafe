using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetLastWeekWorkingTime : IGetLastWeekWorkingTime
    {

        private readonly IUnitOfWork unit;

        public GetLastWeekWorkingTime(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public GetLastWeekWorkingTimeResultDto Execute(GetLastWeekWorkingTimeDto dto)
        {            
            List<WorkTime> work = unit.WorkTime.GetLastWeekWorkingTime(dto);
            List<RegisteredWorkTime> register = unit.RegisteredWorkTime.GetLastWeekWorkingTime(dto);
            List<DailyWorkingTime> lst = new List<DailyWorkingTime>();
            var week = work.GroupBy(p => p.Date.ToDate().DayOfWeek).ToList();
            var registerWeek = register.GroupBy(p => p.Date.ToDate().DayOfWeek).ToList();
            for (int i = 1; i <= 7; i++)
            {
                var date = DateTime.Now.SubDays(-i);
                var search = week.Where(p => p.Key == date.DayOfWeek).ToList().FirstOrDefault();
                var registered = registerWeek.Where(p => p.Key == date.DayOfWeek).ToList().FirstOrDefault();
                int input = 0, output = 0;
                if (search != null)
                {
                    input = search.ToList().Where(p => p.IsInput).ToList().Count;
                    output = search.ToList().Where(p => !p.IsInput).ToList().Count;                    
                }
                if (search == null || search.Count() == 0 || input != output || input == 0)
                    lst.Add(new DailyWorkingTime { Date = date.ToUnix(), Hour = 0 , Status = WorkingTimeStatus.Pending.ToInt() });
                else
                {
                    var sub = search.ToList()[1].Date.ToDate() - search.ToList()[0].Date.ToDate();
                    double hour = sub.Hours;
                    double min = sub.Minutes;
                    int status = WorkingTimeStatus.Pending.ToInt();
                    if (registered != null)
                        status = registered.FirstOrDefault().StatusId;
                    lst.Add(new DailyWorkingTime { Date = date.ToUnix(), Hour =(hour*60+min) /60.00 ,Status = status});
                }

            }
            return new GetLastWeekWorkingTimeResultDto
            {
                Status = true,
                Message = Messages.IsUsed,
                Object = lst
            };
        }
    }
}
