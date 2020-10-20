using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetUserGamesByPageDto : BaseByUserPageDto
    {
        
    }
    public class GetUserGamesByPageResultDto : BaseApiPageResult
    {
        public List<BillGameDto> Object { get; set; }
    }
}
