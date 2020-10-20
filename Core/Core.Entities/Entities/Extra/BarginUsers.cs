using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class BarginUsers
    {
        public Guid Id { get; set; }
        public long CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid BarginCampaignId { get; set; }
        public virtual BarginCampaign BarginCampaign { get; set; }
        public virtual BarginUserBills BarginUserBills { get; set; }

    }
}
