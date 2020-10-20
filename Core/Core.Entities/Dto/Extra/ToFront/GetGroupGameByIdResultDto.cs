using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetGroupGameByIdDto : BaseByIdDto
    {
    }
    public class GetGroupGameByIdResultDto : BaseApiResult
    {
        public GroupGameDto Object { get; set; }
    }
}
