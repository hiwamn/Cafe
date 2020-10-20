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
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly IContext ctx;

        public SliderRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<SliderDto> GetIncludeDocument()
        {
            return ctx.Slider.Include(p => p.Document).Select(p =>new SliderDto {Location = p.Document.Location,Id = p.Id }).ToList();
        }
    }
}
