using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Domain.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.EF.Services
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        private readonly IContext ctx;

        public ProvinceRepository(IContext ctx):base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<Province> GetByCountryId(int? countryId)
        {
            return ctx.Provinces.Where(p => countryId == null || p.CountryId == countryId).OrderBy(p => p.Name).ToList();
        }

       
    }
}
