using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetTablesReserveResultDto : BaseApiResult
    {
        public List<TableReserveDto> Object { get; set; }
    }
}
