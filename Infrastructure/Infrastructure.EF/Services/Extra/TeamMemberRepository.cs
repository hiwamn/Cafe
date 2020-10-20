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
    public class TeamMemberRepository : Repository<TeamMember>, ITeamMemberRepository
    {
        private readonly IContext ctx;

        public TeamMemberRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public TeamMember GetByUserAndTeam(LeftTeamDto dto)
        {
            return ctx.TeamMember.Where(p => p.TeamId == dto.TeamId && p.UserId == dto.UserId).FirstOrDefault();
        }
    }
}
