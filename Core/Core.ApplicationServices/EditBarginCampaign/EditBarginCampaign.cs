using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class EditBarginCampaign : IEditBarginCampaign
    {

        private readonly IUnitOfWork unit;

        public EditBarginCampaign(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(EditBarginCampaignDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.IsUsed };
            BarginCampaign tbl = unit.BarginCampaigns.Get(dto.Id);            
            tbl.Description = dto.Description;                                                            
            unit.Complete();
            return result;
        }
    }
}
