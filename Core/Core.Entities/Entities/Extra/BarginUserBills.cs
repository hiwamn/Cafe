using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class BarginUserBills:BaseEntity
    {
        public Guid BarginUsersId { get; set; }
        public virtual BarginUsers BarginUsers { get; set; }
        public Guid BillId { get; set; }
        public virtual Bill Bill { get; set; }

    }
}
