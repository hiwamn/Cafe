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
    public class AddBillItemForStaff : IAddBillItemForStaff
    {

        private readonly IUnitOfWork unit;
        private readonly IGetWallet getWallet;

        public AddBillItemForStaff(IUnitOfWork unit,IGetWallet getWallet)
        {
            this.unit = unit;
            this.getWallet = getWallet;
        }
        public AddBillItemForStaffResultDto Execute(AddBillItemDto dto)
        {
            AddBillItemForStaffResultDto result = new AddBillItemForStaffResultDto { Status = true, Message = Messages.Success };
            var now = DateTime.Now.ToUnix();
            var max = int.Parse(unit.Setting.GetAll().FirstOrDefault(p => p.Name == "MaxStaffBying").Value);
            var bill = unit.Bills.Get(dto.BillId);
            int alreadyBought = unit.Bills.GetAlreadyBought(bill.UserId);

            if (dto.Count * dto.UnitPrice > getWallet.Execute(new BaseByUserDto { UserId = bill.UserId }).Object)
            {
                result.Status = false;
                result.Message = Messages.MoneyIsNotEnough;
            }
            else if ((dto.Count * dto.UnitPrice) + alreadyBought >max)
            {
                result.Status = false;
                result.Message = Messages.DailyLevelExceeded;
            }
            else
            {
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
                unit.Transactions.Add(new Transaction
                {
                    Amount = -(dto.Count * dto.UnitPrice),
                    BillId = dto.BillId,
                    CreatedAt = now,
                    Description = dto.Description,
                    IsSuccessful = true,
                    TransactionCategoryId = TransactionCategories.BillPay.ToInt(),
                    UserId = bill.UserId
                });
                unit.Complete();
                result.Object = unit.Bills.GetBillById(new BaseByIdDto { Id = dto.BillId });
            }
            return result;
        }
    }
}
