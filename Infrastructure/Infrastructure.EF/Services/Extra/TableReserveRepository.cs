using Core.ApplicationServices;
using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
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
    public class TableReserveRepository : Repository<TableReserve>, ITableReserveRepository
    {
        private readonly IContext ctx;

        public TableReserveRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public TableReserve GetByTableId(Guid tableId)
        {
            return ctx.TableReserve.Where(p => p.TableId == tableId).
                Include(p=>p.Bill).
                OrderBy(p=>p.CreatedAt).
                FirstOrDefault();
        }

        public List<TableReserveDto> GetReserved()
        {
            return ctx.TableReserve.
                //Where(p => p.StatusId == TableStatus.Reserved.ToInt()).
                Include(p => p.Table).
                Include(p=>p.User).ThenInclude(p=>p.ProfileImage).
                OrderByDescending(p=>p.CreatedAt).
                Select(p => DtoBuilder.CreateTableReserveDto(p)).ToList();
        }
    }
}
