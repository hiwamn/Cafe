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
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly IContext ctx;

        public MessageRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public GetAdminMessagesByPageResultDto GetAdminMessagesByPage(GetAdminMessagesByPageDto dto)
        {
            List<Message> message = ctx.Message.                
                Where(p =>
            (dto.UserId == null || p.UserId == dto.UserId) &&
            p.IsFromAdmin
            
            ).
                OrderByDescending(p => p.CreatedAt).AsEnumerable().ToList();

            var res = message.
                Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).
                Select(p => DtoBuilder.CreateMessageDto(p)).
                ToList();
            return new GetAdminMessagesByPageResultDto
            {
                Status = true,
                Object = res,
                Page = new PageDto
                {
                    CurrentCount = res.Count,
                    PageNo = dto.PageNo,
                    TotalCount = message.Count
                }
            };
        }
    }
}
