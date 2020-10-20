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
    public class AddBarginCampaign : IAddBarginCampaign
    {

        private readonly IUnitOfWork unit;

        public AddBarginCampaign(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddBarginCampaignDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            BarginCampaign bc = new BarginCampaign
            {
                CreatedAt = now,
                BarginTypeId = dto.BarginTypeId,
                Description = dto.Description,
                GameTypeId = dto.GameTypeId,
                IsProductDiscount = dto.IsProductDiscount,
                RemainedCount = dto.PaticipantCount,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                StatusId = Enums.EntityStatus.Active.ToInt(),
                TotalCount = dto.PaticipantCount,
                Value = dto.Value
            };
            unit.BarginCampaigns.Add(bc);
            unit.Complete();
            return result;
        }
    }
}
