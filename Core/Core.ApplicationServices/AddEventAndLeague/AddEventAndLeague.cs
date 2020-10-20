using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddEventAndLeague : IAddEventAndLeague
    {

        private readonly IUnitOfWork unit;

        public AddEventAndLeague(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddEventAndLeagueDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            EventAndLeague eal = new EventAndLeague
            {
                CreatedAt = now,
                Description = dto.Description,
                GameTypeId = dto.GameTypeId,
                Name = dto.Name,
                TotalCount = dto.PaticipantCount,
                Price = dto.Price,
                DiscountPrice = dto.DiscountPrice,
                RemainedCount = dto.PaticipantCount - 1,
                StartAt = dto.StartTime,
                StatusId = Enums.EntityStatus.Active.ToInt(),                
                IsEvent = dto.IsEvent,                
            };
            
            unit.EventAndLeagues.Add(eal);
            unit.Complete();
            result.Object = eal;
            return result;
        }
    }
}
