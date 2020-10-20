using Core.ApplicationServices;
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
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly IContext ctx;

        public CityRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<CityDto> GetByProvinceId(GetCitiesDto dto)
        {
            return ctx.Cities.Where(p=>
            (dto.ProvienceId== null || p.ProvinceId == dto.ProvienceId)&&
            (dto.KeyWord == null || dto.KeyWord == "" || p.Name.Contains(dto.KeyWord))).Select(p=>new CityDto { Id = p.Id,Name = p.Name}).ToList();
        }
    }
}
