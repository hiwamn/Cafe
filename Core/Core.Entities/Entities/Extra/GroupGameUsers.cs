using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class GroupGameUsers
    {
        public long CreatedAt { get; set; }
        public Guid UserId{ get; set; }
        public User User{ get; set; }
        public Guid GroupGameId { get; set; }
        public GroupGame GroupGame { get; set; }

    }
}
