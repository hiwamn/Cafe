using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class SearchPeopleDto 
    {
        public string Keyword { get; set; }
        public Guid UserId { get; set; }
    }
    public class SearchPeopleResultDto : BaseApiResult
    {
        public List<UserShortDto> Object { get; set; }
    }
}
