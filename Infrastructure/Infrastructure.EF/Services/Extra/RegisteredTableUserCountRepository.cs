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
    public class RegisteredTableUserCountRepository : Repository<RegisteredTableUserCount>, IRegisteredTableUserCountRepository
    {
        private readonly IContext ctx;

        public RegisteredTableUserCountRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }


    }
}
