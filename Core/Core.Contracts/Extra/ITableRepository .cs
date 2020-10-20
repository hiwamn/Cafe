using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface ITableRepository : IRepository<Table>
    {
        Table GetByBarCode(string barCode);
        List<Table> GetAllByDetails();
    }
}
