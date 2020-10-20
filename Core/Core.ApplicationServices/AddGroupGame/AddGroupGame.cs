using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddGroupGame : IAddGroupGame
    {

        private readonly IUnitOfWork unit;

        public AddGroupGame(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddGroupGameDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            GroupGame gg = new GroupGame
            {
                CreatedAt = now,
                Description = dto.Description,
                GameTypeId = dto.GameTypeId,
                Name = dto.Name,
                TotalCount = dto.TotalCount,
                Price = dto.Price,
                DiscountPrice = dto.DiscountPrice,
                RemainedCount = dto.TotalCount-1,
                StartAt = dto.StartTime,
                StatusId = Enums.EntityStatus.Active.ToInt(),
            };
            unit.GroupGames.Add(gg);
            unit.Complete();
            result.Object = gg;
            return result;
        }
    }
}
