using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class JoinEventDto : BaseByUserDto
    {
        public Guid EventAndLeagueId { get; set; }
    }

}
