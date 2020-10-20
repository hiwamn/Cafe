using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class EventUsers : UserBaseEntity
    {
        public Guid EventAndLeagueId { get; set; }
        public EventAndLeague EventAndLeague { get; set; }

    }
}
