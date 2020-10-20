using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddGameType : IAddGameType
    {

        private readonly IUnitOfWork unit;

        public AddGameType(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddGameTypeDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success };

            GameType gt = new GameType
            {
                Name = dto.Name,
                Id = unit.GameTypes.GetMax<int>(p=>p.Id)+1,
                PricePerFirstHour = dto.PricePerFirstHour,
                PricePerOtherhour = dto.PricePerOtherhour
            };
            unit.GameTypes.Add(gt);
            unit.Complete();
            result.Object = gt;
            return result;
        }
    }
}
