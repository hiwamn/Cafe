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
    public class AddProductRate : IAddProductRate
    {

        private readonly IUnitOfWork unit;

        public AddProductRate(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddProductRateDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success};
            var now = DateTime.Now.ToUnix();

            ProductRate productRate = new ProductRate
            {
                CreatedAt = now,
                StatusId = !dto.IsForAdmin? ProductRateStatus.Pending.ToInt(): ProductRateStatus.Active.ToInt(),
                ParentId = dto.ParentId,
                Comment = dto.Comment,
                ProductId = dto.ProductId,
                Rate = dto.Rate,
                UserId = dto.UserId
            };
            unit.ProductRate.Add(productRate);
            unit.Complete();
            
            return result;
        }
    }
}
