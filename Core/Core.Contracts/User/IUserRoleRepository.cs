using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        List<UserRole> GetByUserId(Guid? userId);
    }
}
