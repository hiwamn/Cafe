using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetAdminMessagesByPageDto : BaseByUserPageDto    
    {

    }
    public class GetAdminMessagesByPageResultDto : BaseApiPageResult
    {
        public List<MessageDto> Object { get; set; }
    }
}
