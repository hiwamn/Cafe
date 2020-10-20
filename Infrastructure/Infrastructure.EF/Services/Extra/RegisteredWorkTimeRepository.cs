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
using Utility.Tools.General;

namespace Infrastructure.EF.Services
{
    public class RegisteredWorkTimeRepository : Repository<RegisteredWorkTime>, IRegisteredWorkTimeRepository
    {
        private readonly IContext ctx;

        public RegisteredWorkTimeRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<RegisteredWorkTime> GetAdminRegisteredDailyWorkingTime(GetAdminRegisteredDailyWorkingTimeDto dto)
        {
            var to = Agent.Now.SubDays(0).ToUnix();
            var from = to.SubDays(1).ToUnix();
            return ctx.RegisteredWorkTime.
                Where(p => p.Date >= from && p.Date <= to ).
                Include(p=>p.User).ThenInclude(p=>p.ProfileImage).
                ToList();
        }

        public List<RegisteredWorkTime> GetLastWeekWorkingTime(GetLastWeekWorkingTimeDto dto)
        {
            var to = Agent.Now.SubDays(0).ToUnix();
            var from = to.SubDays(-7).ToUnix();
            return ctx.RegisteredWorkTime.
                Where(p => p.Date >= from && p.Date <= to && p.UserId == dto.UserId).
                ToList();
        }
    }
}
