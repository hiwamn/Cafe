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
    public class PayFromWallet : IPayFromWallet
    {

        private readonly IUnitOfWork unit;
        private readonly IGetWallet getWallet;
        private readonly IPayBill payBill;

        public PayFromWallet(IUnitOfWork unit,IGetWallet getWallet,IPayBill payBill)
        {
            this.unit = unit;
            this.getWallet = getWallet;
            this.payBill = payBill;
        }
        public BaseApiResult Execute(PayFromWalletDto dto)
        {

            BaseApiResult result = new BaseApiResult { Status = true, Message = Messages.Success, };
            if (getWallet.Execute(new BaseByUserDto { UserId = dto.UserId }).Object < dto.Paid)
            {
                result.Status = false;
                result.Message = Messages.MoneyIsNotEnough;
            }
            else
            {
                var now = DateTime.Now.ToUnix();
                unit.Transactions.Add(new Transaction
                {
                    Amount = -dto.Paid,
                    CreatedAt = Agent.Now,
                    UserId = dto.UserId,
                    TransactionCategoryId = TransactionCategories.BillPay.ToInt(),
                    IsSuccessful = true,
                    BillId = dto.BillId
                });
                unit.Complete();
                payBill.Execute(new PayBillDto { BillId = dto.BillId,StatusId = dto.StatusId});
            }
            return result;
        }
    }
}
