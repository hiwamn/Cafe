using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IBarginUsersRepository : IRepository<BarginUsers>
    {
        BarginUsers GetByUser(JoinBarginCampaignDto dto);
    }
}
