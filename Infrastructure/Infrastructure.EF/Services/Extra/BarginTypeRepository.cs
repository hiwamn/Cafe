using Core.ApplicationServices;
using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Domain.Contract;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.EF.Services
{
    public class BarginTypeRepository : Repository<BarginType>, IBarginTypeRepository
    {
        private readonly IContext ctx;

        public BarginTypeRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        
    }
}
