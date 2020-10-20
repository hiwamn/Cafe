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
    public class DeleteBarginCampaign : IDeleteBarginCampaign
    {

        private readonly IUnitOfWork unit;

        public DeleteBarginCampaign(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(BaseByIdDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.IsUsed};
            var bc = unit.BarginCampaigns.Get(dto.Id);
            try
            {                
                unit.BarginCampaigns.Remove(bc);
                unit.Complete();
                result.Status = true;
                result.Message = Messages.Success;
            }
            catch
            {
            }
            return result;
        }
    }
}

