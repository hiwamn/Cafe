using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetGameTypesDto : BaseByIdDto
    {
    }
    public class GetGameTypesResultDto : BaseApiResult
    {
        public List<GameTypeDto> Object { get; set; }
    }
}
