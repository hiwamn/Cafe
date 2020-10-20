using Core.ApplicationServices;
using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Domain.Contract;
using Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Utility.Tools.General;

namespace Infrastructure.EF.Services
{
    public class BarginCampaignRepository : Repository<BarginCampaign>, IBarginCampaignRepository
    {
        private readonly IContext ctx;

        public BarginCampaignRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public BarginCampaignDto GetBarginCampaignById(BaseByIdDto dto)
        {
            return ctx.BarginCampaigns.
                Where(p => p.StatusId == Enums.EntityStatus.Active.ToInt() && p.Id == dto.Id).
                Include(p => p.BarginType).
                Include(p => p.GameType).
                Include(p => p.BarginUsers).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.BarginUsers).ThenInclude(p => p.User).ThenInclude(p => p.Transaction).
                Select(p => DtoBuilder.CreateBarginCampaignDto(p)).FirstOrDefault();
        }

        public List<BarginCampaignDto> GetBarginCampaignByPage(GetBarginCampaignByPageDto dto)
        {
            var now = Agent.Now;
            var bc = ctx.BarginCampaigns.                
                Include(p => p.BarginUsers).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.BarginUsers).ThenInclude(p => p.User).ThenInclude(p => p.Transaction).
                Where(p => (p.StatusId == Enums.EntityStatus.Active.ToInt()) &&
                (dto.From == 0 || dto.From <= p.CreatedAt && dto.To >= p.CreatedAt) &&
                ((dto.From >= now && p.BarginUsers.Any(q=>q.UserId == dto.UserId) && dto.To>=now) || p.CreatedAt < now ) &&
                (dto.UserId == null || p.BarginUsers.FirstOrDefault(q=>q.UserId == dto.UserId)!=null) &&
                (dto.Type == null || (p.StatusId == dto.Type)) &&
                (dto.StartTime == 0 || dto.StartTime <= p.StartTime && dto.EndTime >= p.EndTime)
                ).
                Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).
                Include(p=>p.BarginType).
                Include(p=>p.GameType).
                Select(p => DtoBuilder.CreateBarginCampaignDto(p)).ToList();
            bc.ForEach(p=> { if (p.Users.Any(q => q.Id == dto.UserId)) p.IsMine = true; });
            return bc;
        }

        public int GetBarginCampaignByPageCount(GetBarginCampaignByPageDto dto)
        {
            var now = Agent.Now;
            return ctx.BarginCampaigns.
                Where(p => (p.StatusId == Enums.EntityStatus.Active.ToInt()) &&
                (dto.From == 0 || dto.From <= p.CreatedAt && dto.To >= p.CreatedAt) &&
                ((dto.From >= now && p.BarginUsers.Any(q => q.UserId == dto.UserId) && dto.To >= now) || p.CreatedAt < now) &&
                (dto.UserId == null || p.BarginUsers.FirstOrDefault(q => q.UserId == dto.UserId) != null) &&
                (dto.Type == null || (p.StatusId == dto.Type)) &&
                (dto.StartTime == 0 || dto.StartTime <= p.StartTime && dto.EndTime >= p.EndTime)
                ).Count();
        }

       

       
    }
}
