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
    public class ActiveCodeRepository :Repository<ActiveCode>, IActiveCodeRepository
    {
        private readonly IContext ctx;

        public ActiveCodeRepository(IContext ctx):base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public bool CheckActiveCode(CheckActiveCodeDto dto)
        {
            var date = DateTime.Now.AddMinutes(-15).ToUnix();
            var result = ctx.ActiveCodes.Where(p => p.Mobile == dto.Mobile && p.CreatedAt > date).OrderByDescending(p=>p.CreatedAt).ToList().FirstOrDefault();
            return result != null && result.Code == dto.ActiveCode;
        }
        public bool CheckExeed(string mobile)
        {
            var date = DateTime.Now.AddMinutes(-15).ToUnix();
            return ctx.ActiveCodes.Where(p => p.Mobile == mobile && p.CreatedAt> date).Count() >= 2;
        }       
    }
}
