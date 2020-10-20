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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly IContext ctx;

        public RoleRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        
    }
}
