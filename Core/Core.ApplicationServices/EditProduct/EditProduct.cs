using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class EditProduct : IEditProduct
    {

        private readonly IUnitOfWork unit;

        public EditProduct(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(EditProductDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.IsUsed };
            Product tbl = unit.Products.Get(dto.Id);
            tbl.ParentId = dto.ParentId;
            tbl.Description = dto.Description;
            tbl.Price = dto.Price;
            tbl.Name = dto.Name;
            tbl.StaffPrice = dto.StaffPrice;
            tbl.StatusId= dto.StatusId;
            unit.ProductImages.AddRange(dto.Images.Select(p=>new ProductImage {CreatedAt = Agent.Now,DocumentId = p,ProductId = tbl.Id }).ToList());
            unit.Complete();
            return result;
        }
    }
}
