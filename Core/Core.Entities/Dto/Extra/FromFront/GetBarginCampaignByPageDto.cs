using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetBarginCampaignByPageDto : BaseByUserPageDto    
    {
        public long StartTime { get; set; }
        public long EndTime { get; set; }
    }
    public class GetBarginCampaignByPageResultDto : BaseApiPageResult
    {
        public List<BarginCampaignDto> Object { get; set; }
    }
}
