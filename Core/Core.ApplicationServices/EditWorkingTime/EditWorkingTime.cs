using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class EditWorkingTime : IEditWorkingTime
    {

        private readonly IUnitOfWork unit;

        public EditWorkingTime(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(EditWorkingTimeDto dto)
        {
            RegisteredWorkTime work = unit.RegisteredWorkTime.Get(dto.Id);

            work.Hour = dto.Hour;
            work.StatusId = dto.Status.ToInt();
            unit.Complete();
            return new BaseApiResult
            {
                Status = true
            };
        }
    }
}
