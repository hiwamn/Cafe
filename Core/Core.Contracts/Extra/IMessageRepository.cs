using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IMessageRepository : IRepository<Message>
    {
        GetAdminMessagesByPageResultDto GetAdminMessagesByPage(GetAdminMessagesByPageDto dto);
    }
}
