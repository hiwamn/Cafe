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
    public class EventUsersRepository : Repository<EventUsers>, IEventUsersRepository
    {
        private readonly IContext ctx;

        public EventUsersRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public EventUsers GetByUserAndEvent(JoinEventDto dto)
        {
            return ctx.EventUsers.Where(p => p.UserId == dto.UserId && p.EventAndLeagueId == dto.EventAndLeagueId).FirstOrDefault();
        }

        public List<EventUsers> GetEventUsers(Guid id)
        {
            return ctx.EventUsers.Where(p => p.EventAndLeagueId == id).ToList();
        }
    }
}
