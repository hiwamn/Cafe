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
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        private readonly IContext ctx;

        public BillRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public GetBillsByPageResultDto GetBillsByPage(BaseByUserPageBillDto dto)
        {
            var bills = ctx.Bills.
                Where(p =>
                (dto.From == 0 || dto.From <= p.CreatedAt && dto.To >= p.CreatedAt) &&
                (dto.UserId == null || p.UserId == dto.UserId) &&
                (dto.TableId == null || p.TableReserve.TableId == dto.TableId) &&
                (dto.Type == 0 || (p.StatusId == BillStatus.Pending.ToInt() && BillStatus.Pending.ToInt() == dto.Type) || (p.StatusId != BillStatus.Pending.ToInt() && BillStatus.Pending.ToInt() != dto.Type)) &&
                (dto.HasUser == null || (dto.HasUser == BillUserType.RegisterUser.ToInt() && p.User != null) || (dto.HasUser == BillUserType.GuestUser.ToInt() && p.User == null)) &&
                (dto.HasDiscount == 0 || (dto.HasDiscount == DiscountType.NoDiscount.ToInt()))
                ).
                Include(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.Promoter).ThenInclude(p => p.ProfileImage).
                Include(p => p.User).ThenInclude(p => p.Transaction).
                Include(p => p.TableReserve).ThenInclude(p => p.Table).
                Include(p => p.BillGames).ThenInclude(p => p.GameType).
                Include(p => p.BillItem).ThenInclude(p => p.Product).ThenInclude(p => p.ProductImages).
                Include(p => p.User).ThenInclude(p => p.BarginUsers).ThenInclude(p => p.BarginCampaign).
                ToList();
            var res = bills.OrderByDescending(p => p.CreatedAt).Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).
                Select(p => DtoBuilder.CreateBillDto(p)).ToList();

            return new GetBillsByPageResultDto
            {
                Object = res,
                Status = true,
                Page = new PageDto
                {
                    PageNo = dto.PageNo,
                    CurrentCount = res.Count,
                    TotalCount = bills.Count,
                    TotalPrice = GetTotalPrice(bills),
                    TotalDiscunt = GetTotalDiscount(bills)
                }
            };
        }
        public BillDto GetBillById(BaseByIdDto dto)
        {
            return ctx.Bills.
                Where(p => p.Id == dto.Id).
                Include(p => p.User).ThenInclude(p => p.ProfileImage).
                Include(p => p.Promoter).ThenInclude(p => p.ProfileImage).
                Include(p => p.User).ThenInclude(p => p.Transaction).
                Include(p => p.TableReserve).ThenInclude(p => p.Table).
                Include(p => p.BillGames).ThenInclude(p => p.GameType).
                Include(p => p.BillItem).ThenInclude(p => p.Product).ThenInclude(p => p.ProductImages).
                Include(p => p.User).ThenInclude(p => p.BarginUsers).ThenInclude(p => p.BarginCampaign).
                Select(p => DtoBuilder.CreateBillDto(p)).FirstOrDefault();
        }

        public GetOrdersByPageResultDto GetOrdersByPage(GetOrdersByPageDto dto)
        {
            List<Bill> bills = ctx.Bills.
                Include(p => p.TableReserve).ThenInclude(p => p.Table).
                Include(p => p.User).
                Include(p => p.BillItem).ThenInclude(p => p.Product).ThenInclude(p => p.ProductImages).
                //Include(p => p.User).ThenInclude(p => p.BarginUsers).ThenInclude(p => p.BarginCampaign).
                Where(p =>
                //(p.BarginCampaigns.Any(q => p.CreatedAt >= q.StartTime && p.CreatedAt <= q.EndTime)) &&
                (dto.UserId == null || dto.UserId == p.UserId) &&
                (dto.TableId == null || dto.TableId == p.TableReserve.TableId) &&
                (dto.From == 0 || (dto.From <= p.CreatedAt && dto.To >= p.CreatedAt))
                ).ToList();
            List<OrderDto> result = bills.OrderByDescending(p => p.CreatedAt).
                Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).
                Select(p => DtoBuilder.CreateOrderDto(p)).ToList();

            return new GetOrdersByPageResultDto
            {
                Object = result,
                Status = true,
                Page = new PageDto
                {
                    PageNo = dto.PageNo,
                    CurrentCount = result.Count,
                    TotalCount = bills.Count,
                    TotalPrice = GetTotalPrice(bills),
                    TotalDiscunt = GetTotalDiscount(bills)
                }
            };
        }

        public Bill GetByUserAndTable(AddProductToTableDto dto)
        {
            return ctx.Bills.
                Include(p => p.TableReserve).
                Where(p => p.TableReserve.TableId == dto.TableId).AsEnumerable().
                OrderByDescending(p => p.CreatedAt).
                FirstOrDefault();
        }

        public Bill GetByTable(Guid tableId)
        {
            return ctx.Bills.
                Include(p => p.TableReserve).
                Where(p => p.TableReserve.TableId == tableId).AsEnumerable().
                OrderByDescending(p => p.CreatedAt).
                FirstOrDefault();
        }

        public List<Bill> GetLastYear(long lastYear)
        {
            return ctx.Bills.Where(p => p.CreatedAt >= lastYear).ToList();
        }

        public int GetAlreadyBought(Guid? userId)
        {
            return ctx.Bills.
                Where(p => p.UserId == userId && p.CreatedAt.ToDate().ToShortDateString() == Agent.Now.SubDays(0).ToShortDateString()).
                Include(p => p.BillItem).AsEnumerable().ToList().Sum(p => p.BillItem.Sum(q => q.UnitPrice * q.Count));
        }
        public long GetTotalPrice(List<Bill> Bills)
        {
            long Sum = Bills.Sum(p => p.BillItem.Sum(q => q.UnitPrice * q.Count));
            Sum += Bills.Sum(
                p => p.BillGames.Sum(q =>
                {
                    var time = (q.To.ToDate() - q.From.ToDate()).TotalMinutes / 60.0;
                    return Convert.ToInt64(q.Count * (q.UnitPriceFirstHour + ((time - 1) <= 0 ? 0 : (time - 1) * q.UnitPriceOtherHour)));
                }));

            return Sum;
        }
        public long GetTotalDiscount(List<Bill> Bills)
        {
            long Sum = Bills.Sum(p => p.User.BarginUsers.Sum(q=>q.BarginCampaign.Value));

            return Sum;
        }
        public Bill GetByDetaill(Guid billId)
        {
            return ctx.Bills.Where(p => p.Id == billId).
                Include(p => p.BillItem).
                Include(p => p.BillGames).
                Include(p => p.User).ThenInclude(p => p.Discount).
                Include(p => p.User).ThenInclude(p => p.BarginUsers).ThenInclude(p => p.BarginCampaign).
                ToList().FirstOrDefault();
        }

        public GetUserGamesByPageResultDto GetUserGamesByPage(GetUserGamesByPageDto dto)
        {
            List<Bill> bills = ctx.Bills.
                Include(p => p.TableReserve).ThenInclude(p => p.Table).
                Include(p => p.User).
                Include(p => p.BillGames).ThenInclude(p => p.GameType).
                //Include(p => p.User).ThenInclude(p => p.BarginUsers).ThenInclude(p => p.BarginCampaign).
                Where(p =>
                //(p.BarginCampaigns.Any(q => p.CreatedAt >= q.StartTime && p.CreatedAt <= q.EndTime)) &&
                (dto.UserId == null || dto.UserId == p.UserId) &&
                
                (dto.From == 0 || (dto.From <= p.CreatedAt && dto.To >= p.CreatedAt))
                ).ToList();
            List<BillGameDto> result = bills.OrderByDescending(p => p.CreatedAt).
                Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).
                Select(p => DtoBuilder.CreateBillGameDto(p)).ToList();

            return new GetUserGamesByPageResultDto
            {
                Object = result,
                Status = true,
                Page = new PageDto
                {
                    PageNo = dto.PageNo,
                    CurrentCount = result.Count,
                    TotalCount = bills.Count,                    
                }
            };
        }
    }
}
