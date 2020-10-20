using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddWorkingTime : IAddWorkingTime
    {

        private readonly IUnitOfWork unit;

        public AddWorkingTime(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddWorkingTimeDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            WorkTime gg = new WorkTime
            {
                CreatedAt = now,
                StatusId = Enums.EntityStatus.Active.ToInt(),
                IsInput = dto.IsInput,
                UserId = dto.UserId,
                Date = dto.Date
            };
            unit.WorkTime.Add(gg);
            unit.Complete();
            return result;
        }
    }
}
