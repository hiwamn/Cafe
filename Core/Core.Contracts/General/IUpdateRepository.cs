using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IUpdateRepository : IRepository<Update>
    {
        Update GetUpdate(string version);
    }
}
