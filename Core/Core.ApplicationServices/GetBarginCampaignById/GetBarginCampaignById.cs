using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetBarginCampaignById : IGetBarginCampaignById
    {
        private readonly IUnitOfWork unit;

        public GetBarginCampaignById(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetBarginCampaignByIdResultDto Execute(BaseByIdDto dto)
        {
            BarginCampaignDto bargins = unit.BarginCampaigns.GetBarginCampaignById(dto);
            return new GetBarginCampaignByIdResultDto
            {
                Object = bargins,
                Status = true
            };
        }
    }

    
}
