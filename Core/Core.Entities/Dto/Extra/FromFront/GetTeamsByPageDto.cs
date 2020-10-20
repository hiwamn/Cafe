using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetTeamsByPageDto : BaseByUserPageDto    
    {

    }
    public class GetTeamsByPageResultDto : BaseApiPageResult
    {
        public List<TeamDto> Object { get; set; }
        public List<RecentTeam> RecentTeam { get; set; }
        public int Price { get; set; }
    }

    public class RecentTeam
    {
        public Guid Id { get; set; }
        public string Name{ get; set; }
        public int Days{ get; set; }
    }
}
