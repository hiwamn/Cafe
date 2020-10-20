using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class JoinBarginCampaign : IJoinBarginCampaign
    {

        private readonly IUnitOfWork unit;

        public JoinBarginCampaign(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(JoinBarginCampaignDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.AlreadyJoined, };
            var now = DateTime.Now.ToUnix();
            BarginUsers bar = unit.BarginUsers.GetByUser(dto);
            if (bar == null)
            {
                BarginUsers bu = new BarginUsers
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = now,
                    BarginCampaignId = dto.BarginCampaignId,
                    UserId = dto.UserId.Value
                };
                unit.BarginUsers.Add(bu);
                unit.Complete();
                result.Status = true;
                result.Message = Messages.Success;
                //result.Object = bi;
            }
            return result;
        }
    }
}
