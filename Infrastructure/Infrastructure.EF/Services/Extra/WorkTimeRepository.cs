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
using Utility.Tools.General;

namespace Infrastructure.EF.Services
{
    public class WorkTimeRepository : Repository<WorkTime>, IWorkTimeRepository
    {
        private readonly IContext ctx;

        public WorkTimeRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<WorkTime> GetAdminDailyWorkingTime(GetAdminDailyWorkingTimeDto dto)
        {
            var to = dto.Date.SubDays(1).ToUnix();
            var from = dto.Date.SubDays(0).ToUnix();
            return ctx.WorkTime.
                Where(p => p.Date >= from && p.Date <= to).
                Include(p => p.User).ThenInclude(p => p.ProfileImage).
                ToList();
        }

        public List<WorkTime> GetDailyWorkingTime(GetDailyWorkingTimeDto dto)
        {
            var to = dto.Date.SubDays(1).ToUnix();
            var from = dto.Date.SubDays(0).ToUnix();
            return ctx.WorkTime.
                Where(p => p.Date >= from && p.Date <= to && (dto.UserId == null || p.UserId == dto.UserId)).
                ToList();
        }

        public List<WorkTime> GetLastWeekWorkingTime(GetLastWeekWorkingTimeDto dto)
        {
            var to = Agent.Now.SubDays(0).ToUnix();
            var from = to.SubDays(-7).ToUnix();
            return ctx.WorkTime.
                Where(p => p.Date >= from && p.Date <= to && p.UserId == dto.UserId).
                ToList();
        }
    }
}
