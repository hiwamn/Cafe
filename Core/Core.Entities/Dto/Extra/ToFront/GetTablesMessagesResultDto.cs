using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetTablesMessagesDto : BaseByPageDto
    {
        public Guid? TableId { get; set; }
        public int Type { get; set; }
    }
    public class GetTablesMessagesResultDto : BaseApiPageResult
    {
        public List<TableMessageDto> Object { get; set; }
    }
}
