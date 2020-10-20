using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class RegisteredWorkTime : UserBaseEntity
    {       
        public int  StatusId{ get; set; }        
        public long Date { get; set; }
        public double Hour{ get; set; }
    }
}
