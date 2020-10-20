using Core.ApplicationServices;
using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Domain.Contract;
using Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.EF.Services
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly IContext ctx;

        public TransactionRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public int GetBalance(BaseByUserDto dto)
        {
            return ctx.Transactions.Where(p => p.UserId == dto.UserId && p.IsSuccessful && p.TransactionCategoryId != TransactionCategories.Cash.ToInt()).Sum(p => p.Amount);
        }

        public Transaction GetByAuthority(string authority)
        {
            return ctx.Transactions.Where(p => p.Authority == authority).ToList().FirstOrDefault();
        }

        public List<Transaction> GetHybridTransactions(GetHybridTransactionsDto dto)
        {
            return ctx.Transactions.Where(p => p.UserId == dto.UserId).
                ToList();
        }

        public List<Transaction> GetLastYear(long lastYear)
        {
            return ctx.Transactions.
                Where(p => p.CreatedAt >= lastYear && p.TransactionCategoryId == TransactionCategories.Salary.ToInt()).
                ToList();
        }

        public List<TransactionDto> GetTransactionsByPage(BaseByUserPageDto dto)
        {
            return ctx.Transactions.
                Where(p => (dto.UserId == null || dto.UserId == p.UserId && p.IsSuccessful) &&
                (dto.From == 0 || dto.From <= p.CreatedAt && dto.To >= p.CreatedAt) &&
                (dto.UserId == null || p.UserId == dto.UserId) &&
                (dto.Type == null || dto.Type == 0 || (p.Type == dto.Type))
                ).
                Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).
                Include(p => p.TransactionCategory).
                Include(p => p.NextUser).ThenInclude(p => p.ProfileImage).
                Include(p => p.Bill).ThenInclude(p => p.BillItem).ThenInclude(p => p.Product).ThenInclude(p => p.ProductImages).ThenInclude(p => p.Document).
                Include(p => p.Bill).ThenInclude(p => p.TableReserve).ThenInclude(p => p.Table).
                Include(p => p.Bill).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.Bill).ThenInclude(p => p.Promoter).ThenInclude(p => p.ProfileImage).ToList().
                Select(p => DtoBuilder.CreateTransactionDto(p)).
                OrderByDescending(p => p.CreatedAt).ToList();
        }

        public int GetTransactionsByPageCount(BaseByUserPageDto dto)
        {
            return ctx.Transactions.
                Where(p => dto.UserId == null || dto.UserId == p.UserId && p.IsSuccessful).Count();
        }
        public long GetTransactionsByPageTotalPrice(BaseByUserPageDto dto)
        {
            return ctx.Transactions.
                Where(p => dto.UserId == null || dto.UserId == p.UserId && p.IsSuccessful).Sum(p => p.Amount);
        }
        public bool IsAuthorityExist(string authority)
        {
            return ctx.Transactions.Any(p => p.Authority == authority);
        }
    }
}
