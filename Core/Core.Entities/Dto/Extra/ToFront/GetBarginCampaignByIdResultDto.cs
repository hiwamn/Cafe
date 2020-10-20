using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetBarginCampaignByIdDto : BaseByIdDto
    {
    }
    public class GetBarginCampaignByIdResultDto : BaseApiResult
    {
        public BarginCampaignDto Object { get; set; }
    }
}
