using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EntityStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BarginCampaign> BarginCampaign { get; set; }
        public List<EventAndLeague> EventAndLeague { get; set; }
        public List<GroupGame> GroupGame { get; set; }
        public List<Product> Product { get; set; }
        public List<Table> Table { get; set; }
        public List<WorkTime> WorkTime { get; set; }
    }
}


