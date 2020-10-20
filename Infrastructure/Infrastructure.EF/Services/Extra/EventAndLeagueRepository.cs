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
    public class EventAndLeagueRepository : Repository<EventAndLeague>, IEventAndLeagueRepository
    {
        private readonly IContext ctx;

        public EventAndLeagueRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public EventAndLeagueDto GetById(BaseByIdDto dto)
        {
            return ctx.EventAndLeagues.
                Where(p => p.Id == dto.Id).
                Include(p => p.GameType).
                Include(p => p.EventUsers).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.EventUsers).ThenInclude(p => p.User).ThenInclude(p => p.Transaction).
                Select(p => DtoBuilder.CreateEventDto(p)).FirstOrDefault();
        }

        GetEventsByPageResultDto IEventAndLeagueRepository.GetEventsByPage(BaseByUserPageDto dto)
        {
            List<EventAndLeague> events = ctx.EventAndLeagues.
                Where(p => p.StatusId == Enums.EntityStatus.Active.ToInt()).
                Include(p => p.EventUsers).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.EventUsers).ThenInclude(p => p.User).ThenInclude(p => p.Transaction).
                Include(p => p.GameType).
                Include(p => p.EventUsers).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.EventUsers).ThenInclude(p => p.User).ThenInclude(p => p.Transaction).ToList();
            var res = events.OrderByDescending(p => p.CreatedAt).
                Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).Select(p => DtoBuilder.CreateEventDto(p)).ToList();
            res.ForEach(p => { if (p.Users.Any(q => q.Id == dto.UserId)) p.IsMine = true; });

            return new GetEventsByPageResultDto
            {
                Object = res.OrderByDescending(p=>p.CreatedAt).ToList(),
                RecentEvent = res.Where(p => p.Users.Any(q => q.Id == dto.UserId) && p.StartTime >= Agent.Now).OrderBy(p => p.StartTime).Select(p => new RecentEvent { StartTime = p.StartTime, Id = p.Id, Name = p.Name, Days = (p.StartTime.ToDate() - Agent.Now.ToDate()).Days }).OrderByDescending(p=>p.StartTime).ToList(),
                Status = true,
                Page = new PageDto
                {
                    PageNo = dto.PageNo,
                    CurrentCount = res.Count,
                    TotalCount = events.Count
                }
            };
        }
    }
}
