using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetAdminDailyWorkingTime : IGetAdminDailyWorkingTime
    {

        private readonly IUnitOfWork unit;

        public GetAdminDailyWorkingTime(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public GetAdminDailyWorkingTimeResultDto Execute(GetAdminDailyWorkingTimeDto dto)
        {
            List<WorkTime> work = unit.WorkTime.GetAdminDailyWorkingTime(dto);
            
            return new GetAdminDailyWorkingTimeResultDto
            {
                Status = true,
                Message = Messages.IsUsed,
                Object = work.GroupBy(p=>p.User).Select(q=>new AdminWorkingTimeDto
                {
                    User = DtoBuilder.CreateShortUserDto(q.Key),
                    WorkingTime = q.ToList().Select(t=>new WorkingTimeDto {IsInput = t.IsInput,Time = t.Date}).ToList()
                }).ToList()
            };
        }
    }
}
