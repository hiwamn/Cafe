using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetTablesDto : BaseByIdDto
    {
    }
    public class GetTablesResultDto : BaseApiResult
    {
        public List<TableDto> Object { get; set; }
    }
}
