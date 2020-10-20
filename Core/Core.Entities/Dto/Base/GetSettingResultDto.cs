
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetSettingResultDto : BaseApiResult
    {
        public SettingDto Object{ get; set; }
    }
}
