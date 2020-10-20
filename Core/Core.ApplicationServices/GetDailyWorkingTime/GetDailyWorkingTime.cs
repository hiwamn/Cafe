using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetDailyWorkingTime : IGetDailyWorkingTime
    {

        private readonly IUnitOfWork unit;

        public GetDailyWorkingTime(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public GetDailyWorkingTimeResultDto Execute(GetDailyWorkingTimeDto dto)
        {
            List<WorkTime> work = unit.WorkTime.GetDailyWorkingTime(dto);
            
            return new GetDailyWorkingTimeResultDto
            {
                Status = true,
                Message = Messages.IsUsed,
                Object = work.Select(p=>new WorkingTimeDto {IsInput = p.IsInput,Time = p.Date }).ToList()
            };
        }
    }
}
