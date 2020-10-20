using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Domain.Contract;
using Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Utility;

namespace Infrastructure.EF.Services
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private readonly IContext ctx;

        public UserRoleRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<UserRole> GetByUserId(Guid? userId)
        {
            return ctx.UserRoles.Where(p=>p.UserId == userId).ToList();
        }
    }
}
