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
    public class UserDiscountRepository : Repository<UserDiscount>, IUserDiscountRepository
    {
        private readonly IContext ctx;

        public UserDiscountRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<UserDiscount> GetLastYear(long lastYear)
        {
            return ctx.UserDiscount.Where(p=>p.CreatedAt>= lastYear).ToList();
        }
    }
}
