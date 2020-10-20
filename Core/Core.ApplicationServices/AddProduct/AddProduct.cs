using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddProduct : IAddProduct
    {

        private readonly IUnitOfWork unit;

        public AddProduct(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddProductDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            Product product = new Product
            {
                CreatedAt = now,
                Name = dto.Name,
                StatusId = ProductStatus.Active.ToInt(),
                Description = dto.Description,
                ParentId = dto.ParentId,
                Price = dto.Price,
                ProductImages = dto.Images.Select(p=>new ProductImage {CreatedAt = now,DocumentId = p }).ToList(),
                StaffPrice = dto.StaffPrice
            };
            unit.Products.Add(product);
            unit.Complete();
            
            return result;
        }
    }
}
