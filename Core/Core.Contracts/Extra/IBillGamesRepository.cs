using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IBillGamesRepository : IRepository<BillGames>
    {
        BillGames GetLast(Guid id);
    }
}
