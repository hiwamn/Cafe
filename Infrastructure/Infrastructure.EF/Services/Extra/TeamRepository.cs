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
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private readonly IContext ctx;

        public TeamRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public GetTeamsByPageResultDto GetTeamsByPage(GetTeamsByPageDto dto)
        {
            var team = ctx.Team.
                Include(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.TeamMember).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).               
                OrderByDescending(p => p.CreatedAt).
                Select(p => DtoBuilder.CreateTeamDto(p, dto.UserId)).
                ToList();

            var res = team.
            Skip((dto.PageNo - 1) * AdminSettings.Block).
            Take(AdminSettings.Block).
            ToList();

            return new GetTeamsByPageResultDto
            {
                Object = res,
                RecentTeam = team.Where(p => p.Members.Any(q => q.Id == dto.UserId) && p.Date >= Agent.Now).OrderBy(p => p.Date).Select(p => new RecentTeam { Id = p.Id, Name = "Р—же " + p.Owner.Name, Days = (p.Date.ToDate() - Agent.Now.ToDate()).Days }).ToList(),
                Status = true,
                Page = new PageDto
                {
                    CurrentCount = res.Count,
                    PageNo = dto.PageNo,
                    TotalCount = team.Count
                },
                Price = int.Parse(ctx.Settings.FirstOrDefault(p => p.Name == "TeamPrice").Value)
            };
        }
    }
}
