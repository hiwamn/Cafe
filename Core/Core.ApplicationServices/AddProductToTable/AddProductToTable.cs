using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class AddProductToTable : IAddProductToTable
    {

        private readonly IUnitOfWork unit;
        private readonly IGetUserById getUserById;
        private readonly ICalculatePrice calculatePrice;

        public AddProductToTable(
            IUnitOfWork unit,
            IGetUserById getUserById,
            ICalculatePrice calculatePrice)
        {
            this.unit = unit;
            this.getUserById = getUserById;
            this.calculatePrice = calculatePrice;
        }
        public ApiResult Execute(AddProductToTableDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();
            Product prod = unit.Products.Get(dto.ProductId);
            Bill bill = unit.Bills.GetByUserAndTable(dto);
            //List<bill> 
            BillItem billItem = new BillItem { BillId = bill.Id, Count = dto.Count, CreatedAt = now, Description = dto.Description, ProductId = dto.ProductId, UnitPrice = prod.Price };
            unit.BillItems.Add(billItem);
            if (dto.UserId != bill.UserId)
                bill.PromoterId = dto.UserId;
            unit.Complete();
            bill.Paid = calculatePrice.Execute(new CalculatePriceDto { BillId = bill.Id }).Object;
            unit.Complete();
            if(bill.UserId != null)
            result.Object = getUserById.Execute(new GetUserByIdDto { UserId = bill.UserId }).Object;
            return result;
        }
    }
}
