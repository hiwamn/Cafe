using Core.ApplicationServices;
using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
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
    public class TableRepository : Repository<Table>, ITableRepository
    {
        private readonly IContext ctx;

        public TableRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<Table> GetAllByDetails()
        {
            return ctx.Tables.
                Include(p => p.TableReserve).ThenInclude(p => p.Bill).ThenInclude(p=>p.User).ThenInclude(p=>p.ProfileImage).
                Include(p => p.TableReserve).ThenInclude(p => p.Bill).ThenInclude(p => p.BillItem).ThenInclude(p=>p.Product).ThenInclude(p=>p.ProductImages).
                Include(p => p.TableReserve).ThenInclude(p => p.Bill).ThenInclude(p => p.BillGames).ThenInclude(p=>p.GameType).
                ToList();
        }

        public Table GetByBarCode(string barCode)
        {
            return ctx.Tables.OrderByDescending(p => p.CreatedAt).Where(p => p.BarCode == barCode).FirstOrDefault();
        }
    }
}
