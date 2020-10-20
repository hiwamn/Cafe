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
    public class GroupGameRepository : Repository<GroupGame>, IGroupGameRepository
    {
        private readonly IContext ctx;

        public GroupGameRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public GroupGameDto GetById(BaseByIdDto dto)
        {
            return ctx.GroupGames.                 
                 Where(p =>p.Id == dto.Id).
                 Include(p => p.GroupGameUsers).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).
                 Include(p => p.GroupGameUsers).ThenInclude(p => p.User).ThenInclude(p => p.Transaction).
                 Include(p => p.GameType).
                 Select(p => DtoBuilder.CreateGroupGameDto(p)).FirstOrDefault();
        }

       

       

        GetGroupGamesByPageResultDto IGroupGameRepository.GetGroupGamesByPage(BaseByUserPageDto dto)
        {

            var gg = ctx.GroupGames.
                Include(p => p.GroupGameUsers).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.GroupGameUsers).ThenInclude(p => p.User).ThenInclude(p => p.Transaction).
                Where(p => (p.StatusId == Enums.EntityStatus.Active.ToInt()) &&
                (dto.From == 0 || (dto.From <= p.CreatedAt && dto.To >= p.CreatedAt))
                ).
                Include(p => p.GameType).
                OrderByDescending(p => p.CreatedAt).
                Select(p => DtoBuilder.CreateGroupGameDto(p)).
                ToList();
           
            var res = gg.
                Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).                
                ToList();
            res.ForEach(p => 
            { 
                if (p.Users.Any(q => q.Id == dto.UserId)) 
                    p.IsMine = true; 
            });
            
            
            return new GetGroupGamesByPageResultDto
            {
                Object = res,
                RecentGame = gg.Where(p => p.Users.Any(q=>q.Id == dto.UserId) && p.StartTime >= Agent.Now).OrderBy(p => p.StartTime).Select(p => new RecentGame { Id = p.Id, Name = p.Name !=null && p.Name!=""?p.Name:$"Р—же" , Days = (p.StartTime.ToDate() - Agent.Now.ToDate()).Days }).ToList(),
                Status = true,
                Page = new PageDto
                {
                    PageNo = dto.PageNo,
                    CurrentCount = res.Count,
                    TotalCount = gg.Count
                }
            };
        }
    }
}
