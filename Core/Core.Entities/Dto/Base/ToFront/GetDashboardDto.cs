using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetDashboardDto
    {

    }
    public class GetDashboardResultDto : BaseApiResult
    {
        public Dashboard Object { get; set; }
    }

    public class Dashboard
    {
        public List<DailyVisitHour> LastWeekHours { get; set; }
        public List<DailyVisitCount> LastWeekCount { get; set; }
        public List<DailyVisitHour> LastYearHours { get; set; }
        public List<DailyVisitCount> LastYearCount { get; set; }
        public List<DailyVisitCount> LastWeekBenefit { get; set; }
        public List<DailyVisitCount> LastWeekDiscount { get; set; }
        public List<DailyVisitCount> LastYearBenefit { get; set; }
        public List<DailyVisitCount> LastYearDiscount { get; set; }

        public List<DailyVisitHour> LastMonthHours { get; set; }
        public List<DailyVisitCount> LastMonthCount { get; set; }
        public List<DailyVisitCount> LastMonthBenefit { get; set; }
        public List<DailyVisitCount> LastMonthDiscount { get; set; }
        public int UserCount { get; set; }
        public int StaffCount { get; set; }
        public int BillCount { get; set; }
        public int ProductCount { get; set; }
    }

    public class DailyVisitHour
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double Hour { get; set; }
    }
    public class DailyVisitCount
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
    }

}
