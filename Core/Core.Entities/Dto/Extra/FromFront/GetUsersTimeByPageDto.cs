using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetUsersTimeByPageDto : BaseByPageDto    
    {          
    }
    public class GetUsersTimeByPageResultDto : BaseApiPageResult
    {
        public List<UserLastVisitTimeDto> Object { get; set; }
    }
}
