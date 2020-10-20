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
    public class GetAdminRegisteredDailyWorkingTime : IGetAdminRegisteredDailyWorkingTime
    {

        private readonly IUnitOfWork unit;

        public GetAdminRegisteredDailyWorkingTime(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public GetAdminRegisteredDailyWorkingTimeResultDto Execute(GetAdminRegisteredDailyWorkingTimeDto dto)
        {
            List<RegisteredWorkTime> work = unit.RegisteredWorkTime.GetAdminRegisteredDailyWorkingTime(dto);
            
            return new GetAdminRegisteredDailyWorkingTimeResultDto
            {
                Status = true,
                Message = Messages.IsUsed,
                Object = work.Select(q=>new AdminRegisteredWorkingTimeDto 
                {
                    User = DtoBuilder.CreateShortUserDto(q.User),
                    Hour = q.Hour,
                    Id = q.Id
                }).ToList()
            };
        }
    }
}
