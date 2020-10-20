using Core.Contracts;
using Core.Entities;
using Domain.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.EF.Services
{
    public class UpdateRepository : Repository<Update>, IUpdateRepository
    {
        private readonly IContext ctx;

        public UpdateRepository(IContext ctx):base(ctx as DbContext)
        {
            this.ctx = ctx;
        }
     


        public Update GetUpdate(string version)
        {
            return ctx.Updates.Where(p => int.Parse(p.Version) > int.Parse(version)).ToList().OrderByDescending(p => p.CreatedAt).FirstOrDefault();
        }
    }
}
