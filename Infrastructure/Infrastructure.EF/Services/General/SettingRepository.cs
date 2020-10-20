using Core.Contracts;
using Core.Entities;
using Domain.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.EF.Services
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly IContext ctx;

        public SettingRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }
    }
}
