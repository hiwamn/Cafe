using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class Team : UserBaseEntity
    {
        public long Date{ get; set; }
        public int MaxCount{ get; set; }
        public List<TeamMember> TeamMember { get; set; }
        public int Remained { get; set; }
        public int Price { get; internal set; }
        public string Description { get; set; }
    }
}
