using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class UserTransactionList : UserBaseEntity
    {
        public Guid PartnerId{ get; set; }
        public User Partner{ get; set; }
    }
}
