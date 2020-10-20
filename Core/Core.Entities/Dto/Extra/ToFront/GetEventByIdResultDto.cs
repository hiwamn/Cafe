using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetEventByIdDto : BaseByIdDto
    {
    }
    public class GetEventByIdResultDto : BaseApiResult
    {
        public EventAndLeagueDto Object { get; set; }
    }
}
