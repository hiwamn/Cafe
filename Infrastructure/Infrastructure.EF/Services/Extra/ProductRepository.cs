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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IContext ctx;

        public ProductRepository(IContext ctx) : base(ctx as DbContext)
        {
            this.ctx = ctx;
        }

        public List<AdminProductDto> GetAdminProducts(GetProductsDto dto)
        {
            if (!dto.IncludeChildren)
                return ctx.Products.
                    Where(p => p.ParentId == dto.ParentId).
                    Include(p => p.ProductImages).ThenInclude(p => p.Document).
                    Include(p => p.Parent).
                    Select(p => DtoBuilder.CreateAdminProductDto(p)).
                    ToList();
            return ctx.Products.
                Where(p => p.ParentId == dto.ParentId).
                    Include(p => p.ProductImages).ThenInclude(p => p.Document).
                    Include(p => p.Parent).
                Include(p => p.Children).ThenInclude(q => q.ProductImages).ThenInclude(t => t.Document).AsEnumerable().
                Select(p => DtoBuilder.CreateAdminProductDto(p)).
                    ToList();
        }

        public List<ProductDto> GetProducts(GetProductsDto dto)
        {
            if (!dto.IncludeChildren)
                return ctx.Products.
                    Where(p => p.StatusId == ProductStatus.Active.ToInt() &&  p.ParentId == dto.ParentId).
                        OrderBy(p => p.CreatedAt).
                        Include(p => p.ProductImages).ThenInclude(p=>p.Document).
                        Select(p => DtoBuilder.CreateProductDto(p)).
                    ToList();
            return ctx.Products.
                    Where(p => p.StatusId == ProductStatus.Active.ToInt() && p.ParentId == dto.ParentId).
                        OrderBy(p => p.CreatedAt).
                        Include(p => p.ProductImages).ThenInclude(p => p.Document).
                        Include(p=>p.Children).ThenInclude(q=> q.ProductImages).ThenInclude(t => t.Document).AsEnumerable().                
                        Select(p => DtoBuilder.CreateProductDto(p)).
                    ToList();
        }
    }
}
