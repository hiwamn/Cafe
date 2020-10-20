using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetGroupGamesByPageDto : BaseByUserPageDto
    {

    }
    public class GetGroupGamesByPageResultDto : BaseApiPageResult
    {
        public List<GroupGameDto> Object { get; set; }
        public List<RecentGame> RecentGame { get; set; }
    }

    public class RecentGame
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
    }


}
