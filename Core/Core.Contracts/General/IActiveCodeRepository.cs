using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IActiveCodeRepository : IRepository<ActiveCode>
    {
        bool CheckExeed(string mobile);
        bool CheckActiveCode(CheckActiveCodeDto dto);
    }
}
