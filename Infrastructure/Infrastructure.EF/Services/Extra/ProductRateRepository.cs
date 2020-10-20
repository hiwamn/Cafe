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
    public class ProductRateRepository : Repository<ProductRate>, IProductRateRepository
    {
        private readonly IContext ctx;

        public ProductRateRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public GetProductRatesByPageResultDto GetProductRatesByPage(GetProductRatesByPageDto dto)
        {
            List<ProductRate> products = ctx.ProductRate.Where(p =>
            (dto.StatusId == 0 || p.StatusId == dto.StatusId) &&
            (dto.UserId == null || p.UserId == dto.UserId) &&
            (dto.From == 0 || (p.CreatedAt >= dto.From && p.CreatedAt <= dto.To)) &&
            p.ParentId == null
            ).
            Include(p=>p.Children).ThenInclude(p => p.Product).ThenInclude(p => p.ProductImages).ThenInclude(p => p.Document).
            Include(p => p.Children).ThenInclude(p => p.User).ThenInclude(p => p.ProfileImage).
            Include(p=>p.Product).ThenInclude(p=>p.ProductImages).ThenInclude(p=>p.Document).
            Include(p=>p.User).ThenInclude(p=>p.ProfileImage).
            AsEnumerable().
            ToList();
            var res = products.OrderByDescending(P => P.CreatedAt).
                Skip((dto.PageNo - 1) * AdminSettings.Block).
                Take(AdminSettings.Block).Select(p=>DtoBuilder.CreateProductRateDto(p)).ToList();
            return new GetProductRatesByPageResultDto
            {
                Status = true,
                Object = res,
                Page = new PageDto
                {
                    CurrentCount = res.Count,
                    PageNo = dto.PageNo,
                    TotalCount = products.Count
                }
            };
        }
    }
}
