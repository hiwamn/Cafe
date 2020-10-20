using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class UserDiscount : UserBaseEntity
    {
        public long From { get; set; }
        public long To { get; set; }
        public int Percent{ get; set; }
    }
}
