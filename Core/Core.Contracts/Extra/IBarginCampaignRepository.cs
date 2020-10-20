using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IBarginCampaignRepository : IRepository<BarginCampaign>
    {
        BarginCampaignDto GetBarginCampaignById(BaseByIdDto dto);
        int GetBarginCampaignByPageCount(GetBarginCampaignByPageDto dto);
        List<BarginCampaignDto> GetBarginCampaignByPage(GetBarginCampaignByPageDto dto);
    }
}
