using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class TeamMember : UserBaseEntity
    {
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
