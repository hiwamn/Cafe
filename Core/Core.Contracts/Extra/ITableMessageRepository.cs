using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface ITableMessageRepository : IRepository<TableMessage>
    {
        GetTablesMessagesResultDto GetTablesMessagesByPage(GetTablesMessagesDto dto);
    }
}
