using System;
using System.Collections.Generic;
using System.Text;
using Utility.Tools.Auth;

namespace Core.Entities
{
    public class GameType
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int PricePerFirstHour { get; set; }
        public int PricePerOtherhour { get; set; }
        public List<EventAndLeague> EventAndLeague { get; set; }
        public List<GroupGame> GroupGame { get; set; }
    }
}
