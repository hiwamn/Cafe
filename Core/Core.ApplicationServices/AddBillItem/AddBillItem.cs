using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddBillItem : IAddBillItem
    {

        private readonly IUnitOfWork unit;

        public AddBillItem(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(AddBillItemDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();

            BillItem bi = new BillItem
            {
                BillId = dto.BillId,
                CreatedAt = now,
                Count = dto.Count,
                Description = dto.Description,
                ProductId = dto.ProductId,
                UnitPrice = dto.UnitPrice
            };
            unit.BillItems.Add(bi);
            unit.Complete();
            result.Object = bi;
            return result;
        }
    }
}
