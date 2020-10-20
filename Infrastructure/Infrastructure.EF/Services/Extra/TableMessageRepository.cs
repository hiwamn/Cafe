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

namespace Infrastructure.EF.Services
{
    public class TableMessageRepository : Repository<TableMessage>, ITableMessageRepository
    {
        private readonly IContext ctx;

        public TableMessageRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public GetTablesMessagesResultDto GetTablesMessagesByPage(GetTablesMessagesDto dto)
        {
            List<TableMessage> tableMessage = ctx.TableMessage.
                Where(p=>
                (dto.TableId == null || dto.TableId == p.TableId)&&
                (dto.Type == 0 || dto.Type == p.Type)).
                Include(p => p.Table).
                OrderByDescending(p => p.CreatedAt).ToList();

            var res = tableMessage.
            Skip((dto.PageNo - 1) * AdminSettings.Block).
            Take(AdminSettings.Block).
            Select(p => DtoBuilder.CreateTableMessageDto(p)).ToList();

            return new GetTablesMessagesResultDto
            {
                Object = res,
                Status = true,
                Page = new PageDto
                {
                    CurrentCount = res.Count,
                    PageNo = dto.PageNo,
                    TotalCount = tableMessage.Count
                }
            };
        }
    }
}
