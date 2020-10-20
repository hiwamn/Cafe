using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class EditGameType : IEditGameType
    {

        private readonly IUnitOfWork unit;

        public EditGameType(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(EditGameTypeDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.IsUsed };
            var gt = unit.GameTypes.Get(dto.Id);
            gt.Name = dto.Name;
            gt.PricePerFirstHour = dto.PricePerFirstHour;
            gt.PricePerOtherhour = dto.PricePerOtherhour;
            unit.Complete();
            return result;
        }
    }
}
