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
    public class AcceptWorkingTime : IAcceptWorkingTime
    {

        private readonly IUnitOfWork unit;

        public AcceptWorkingTime(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(AcceptWorkingTimeDto dto)
        {
          
            BaseApiResult result = new BaseApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();
            var work = unit.WorkTime.GetDailyWorkingTime(new GetDailyWorkingTimeDto {Date = dto.Date,UserId = dto.UserId });

            var input = work.Where(p => p.IsInput).ToList();
            var output = work.Where(p => !p.IsInput).ToList();
            double total =0;
            for (int i = 0; i < output.Count; i++)
                total += (output[i].Date.ToDate() - input[i].Date.ToDate()).TotalMinutes / 60.00;
            unit.RegisteredWorkTime.Add(new RegisteredWorkTime
            {
                UserId = dto.UserId,
                StatusId = WorkingTimeStatus.Accepted.ToInt(),
                CreatedAt = now,
                Date = dto.Date,
                Hour = total                
            });
            unit.Complete();
            
            return result;
        }
    }
}
