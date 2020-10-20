using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetDashboard : IGetDashboard
    {

        private readonly IUnitOfWork unit;

        public GetDashboard(
            IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public GetDashboardResultDto Execute(GetDashboardDto dto)
        {
            long now = Agent.Now.SubDays(0).ToUnix();
            long month = Agent.Now.SubDays(-DateTime.Now.Day).ToUnix();

            long lastWeek = Agent.Now.SubDays(-7).ToUnix();
            long lastYear = month.SubDays(-365).ToUnix();


            List<Bill> bill = unit.Bills.GetLastYear(lastYear);
            List<Transaction> trans = unit.Transactions.GetLastYear(lastYear);
            List<UserDiscount> dis = unit.UserDiscount.GetLastYear(lastYear);
            List<User> users = unit.Users.GetAllIncludeRoles();

            List<DailyVisitCount> dailyCount = new List<DailyVisitCount>();
            List<DailyVisitCount> monthCount = new List<DailyVisitCount>();

            List<DailyVisitHour> dailyHour = new List<DailyVisitHour>();
            List<DailyVisitHour> monthHour = new List<DailyVisitHour>();

            List<DailyVisitCount> dailyBenefit = new List<DailyVisitCount>();
            List<DailyVisitCount> monthBenefit = new List<DailyVisitCount>(); 
            
            List<DailyVisitCount> dailyDis = new List<DailyVisitCount>();
            List<DailyVisitCount> monthDis = new List<DailyVisitCount>();

            List<DailyVisitHour> lastMonthHour = new List<DailyVisitHour>();
            List<DailyVisitCount> lastMonthCount = new List<DailyVisitCount>();
            List<DailyVisitCount> lastMonthDis = new List<DailyVisitCount>();
            List<DailyVisitCount> lastMonthBenefit = new List<DailyVisitCount>();
            long to = now;
            long from = now.SubDays(-1).ToUnix();
            for (int i = 1; i <= 7; i++)
            {
                var persian = from.ToPersianDate();
                var day = bill.Where(p => p.CreatedAt >= from && p.CreatedAt <= to).ToList();
                var dayTrans = trans.Where(p => p.CreatedAt >= from && p.CreatedAt <= to).ToList();
                var dayDis = dis.Where(p => p.CreatedAt >= from && p.CreatedAt <= to).ToList();
                dailyCount.Add(new DailyVisitCount { Day = persian.Day,Month = persian.Month,Year = persian.Year, Count = day.Count });
                dailyHour.Add(new DailyVisitHour { Day = persian.Day, Month = persian.Month, Year = persian.Year, Hour = day.Sum(p => (p.CreatedAt.ToDate() - p.UpdatedAt.ToDate()).TotalMinutes / 60.00) });
                dailyBenefit.Add(new DailyVisitCount { Day = persian.Day, Month = persian.Month, Year = persian.Year, Count = day.Sum(p=>p.Paid) - dayTrans.Sum(p=>p.Amount) });
                dailyDis.Add(new DailyVisitCount { Day = persian.Day, Month = persian.Month, Year = persian.Year, Count = dayDis.Count});
                to = from;
                from = from.SubDays(-1).ToUnix();
            }

            to = month;
            from = to.SubDays(-30).ToUnix();
            for (int i = 1; i <= 12; i++)
            {
                var persian = from.ToPersianDate();
                var day = bill.Where(p => p.CreatedAt >= from && p.CreatedAt <= to).ToList();
                var dayTrans = trans.Where(p => p.CreatedAt >= from && p.CreatedAt <= to).ToList();
                var dayDis = dis.Where(p => p.CreatedAt >= from && p.CreatedAt <= to).ToList();
                monthCount.Add(new DailyVisitCount { Day = persian.Day, Month = persian.Month, Year = persian.Year, Count = day.Count });
                monthHour.Add(new DailyVisitHour { Day = persian.Day, Month = persian.Month, Year = persian.Year, Hour = day.Sum(p => (p.CreatedAt.ToDate() - p.UpdatedAt.ToDate()).TotalMinutes / 60.00) });


                monthBenefit.Add(new DailyVisitCount { Day = persian.Day, Month = persian.Month, Year = persian.Year, Count = day.Sum(p => p.Paid) - dayTrans.Sum(p => p.Amount) });
                monthDis.Add(new DailyVisitCount { Day = persian.Day, Month = persian.Month, Year = persian.Year, Count = dayDis.Count });
                to = from;
                from = from.SubDays(-30).ToUnix();
            }

            to = month;
            from = to.SubDays(-1).ToUnix();
            for (int i = 1; i <= 30; i++)
            {
                var persian = from.ToPersianDate();
                var day = bill.Where(p => p.CreatedAt >= from && p.CreatedAt <= to).ToList();
                var dayTrans = trans.Where(p => p.CreatedAt >= from && p.CreatedAt <= to).ToList();
                var dayDis = dis.Where(p => p.CreatedAt >= from && p.CreatedAt <= to).ToList();
                
                
                lastMonthCount.Add(new DailyVisitCount { Day = persian.Day, Month = persian.Month, Year = persian.Year, Count = day.Count });
                lastMonthHour.Add(new DailyVisitHour { Day = persian.Day, Month = persian.Month, Year = persian.Year, Hour = day.Sum(p => (p.CreatedAt.ToDate() - p.UpdatedAt.ToDate()).TotalMinutes / 60.00) });
                lastMonthBenefit.Add(new DailyVisitCount { Day = persian.Day, Month = persian.Month, Year = persian.Year, Count = day.Sum(p => p.Paid) - dayTrans.Sum(p => p.Amount) });
                lastMonthDis.Add(new DailyVisitCount { Day = persian.Day, Month = persian.Month, Year = persian.Year, Count = dayDis.Count });
                to = from;
                from = from.SubDays(-1).ToUnix();
            }

            return new GetDashboardResultDto
            {
                Object = new Dashboard
                {
                    LastWeekCount = dailyCount,
                    LastWeekHours = dailyHour,
                    LastYearCount = monthCount,
                    LastYearHours = monthHour,
                    UserCount = users.Where(p => p.UserRole == null || p.UserRole.Count == 0).ToList().Count,
                    StaffCount = users.Where(p => p.UserRole != null && p.UserRole.Count != 0).ToList().Count,                    
                    LastMonthBenefit = lastMonthBenefit,
                    LastMonthCount = lastMonthCount,
                    LastMonthDiscount = lastMonthDis,
                    LastMonthHours = lastMonthHour,
                    LastWeekBenefit = dailyBenefit,
                    LastWeekDiscount = dailyDis,
                    LastYearBenefit = monthBenefit,
                    LastYearDiscount = monthDis,
                    BillCount = unit.Bills.GetCount(),
                    ProductCount = unit.Products.GetCount()
                },
                Status = true
            };
        }
    }


}
