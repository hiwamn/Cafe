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
    public class GroupGameUsersRepository : Repository<GroupGameUsers>, IGroupGameUsersRepository
    {
        private readonly IContext ctx;

        public GroupGameUsersRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public GroupGameUsers GetByUserAndGame(LeftGroupGameDto dto)
        {
            return ctx.GroupGameUsers.Where(p => p.UserId == dto.UserId && p.GroupGameId== dto.GroupGameId).FirstOrDefault();
        }

        public List<GroupGameUsers> GetGameUsers(Guid id)
        {
            return ctx.GroupGameUsers.Where(p => p.GroupGameId == id).ToList();
        }
    }
}
