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
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly IContext ctx;

        public CountryRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

      
    }
}
