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
    public class EntityStatusRepository : Repository<EntityStatus>, IEntityStatusRepository
    {
        private readonly IContext ctx;

        public EntityStatusRepository(IContext ctx):base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public bool CheckActiveCode(CheckActiveCodeDto dto)
        {
            var date = DateTime.Now.AddMinutes(-15);
            var result = ctx.ActiveCodes.LastOrDefault(p => p.Mobile == dto.Mobile && p.CreatedAt.ToDate() > date);
            return result != null && result.Code == dto.ActiveCode;
        }

        public bool CheckExeed(string mobile)
        {
            var date = DateTime.Now.AddMinutes(-15);
            return ctx.ActiveCodes.Count(p => p.Mobile == mobile && p.CreatedAt.ToDate() > date) >= 2;
        }

       
    }
}
