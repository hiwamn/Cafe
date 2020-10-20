using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IGroupGameRepository : IRepository<GroupGame>
    {
        GroupGameDto GetById(BaseByIdDto dto);
        GetGroupGamesByPageResultDto GetGroupGamesByPage(BaseByUserPageDto dto);
    }
}
