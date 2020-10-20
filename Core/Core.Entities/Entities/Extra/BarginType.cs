using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class BarginType 
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public List<BarginCampaign> BarginCampaign { get; set; }

    }
}
