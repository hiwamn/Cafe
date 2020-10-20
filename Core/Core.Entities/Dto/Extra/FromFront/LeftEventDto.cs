using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class LeftEventDto : BaseByUserDto
    {
        public Guid EventAndLeagueId { get; set; }
    }

}
