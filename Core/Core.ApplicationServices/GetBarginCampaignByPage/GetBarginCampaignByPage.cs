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
    public class GetBarginCampaignByPage : IGetBarginCampaignByPage
    {
        private readonly IUnitOfWork unit;

        public GetBarginCampaignByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetBarginCampaignByPageResultDto Execute(GetBarginCampaignByPageDto dto)
        {
            List<BarginCampaignDto> bargins = unit.BarginCampaigns.GetBarginCampaignByPage(dto);
            return new GetBarginCampaignByPageResultDto
            {
                Object = bargins,
                Status = true,
                Page = new PageDto
                {
                    PageNo = dto.PageNo,
                    CurrentCount = bargins.Count,
                    TotalCount= unit.BarginCampaigns.GetBarginCampaignByPageCount(dto)
                }
            };
        }
    }

    
}
