using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class WorkTime : BaseEntity
    {
        public User User { get; set; }
        public Guid UserId{ get; set; }
        public bool  IsInput{ get; set; }
        public int  StatusId{ get; set; }
        public EntityStatus Status { get; set; }
        public long Date { get; set; }
    }
}
