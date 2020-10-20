using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class Message : UserBaseEntity
    {
        public string Text{ get; set; }
        public bool IsFromAdmin { get; set; }
        public bool IsSeen{ get; set; }
    }
}
