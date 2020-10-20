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
    public class AcceptAllWorkingTime : IAcceptAllWorkingTime
    {

        private readonly IUnitOfWork unit;

        public AcceptAllWorkingTime(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(AcceptAllWorkingTimeDto dto)
        {

            BaseApiResult result = new BaseApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();
            var work = unit.WorkTime.GetDailyWorkingTime(new GetDailyWorkingTimeDto { Date = dto.Date, UserId = null }).
                GroupBy(p => p.UserId).ToList();


            work.ForEach(p =>
            {
                var input = p.Where(p => p.IsInput).ToList();
                var output = p.Where(p => !p.IsInput).ToList();
                double total = 0;
                for (int i = 0; i < output.Count; i++)
                    total += (output[i].Date.ToDate() - input[i].Date.ToDate()).TotalMinutes / 60.00;
                unit.RegisteredWorkTime.Add(new RegisteredWorkTime
                {
                    UserId = p.Key,
                    StatusId = WorkingTimeStatus.Accepted.ToInt(),
                    CreatedAt = now,
                    Date = dto.Date,
                    Hour = total
                });

            });
            unit.Complete();

            return result;
        }
    }
}
