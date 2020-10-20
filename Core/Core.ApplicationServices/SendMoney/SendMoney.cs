using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Utility.Tools.General;
using Utility.Tools.Notification;

namespace Core.ApplicationServices
{
    public class SendMoney : ISendMoney
    {
        private readonly IUnitOfWork unit;


        public SendMoney(IUnitOfWork unit)
        {
            this.unit = unit;

        }

        public BaseApiResult Execute(SendMoneyDto dto)
        {
            BaseApiResult Result = new BaseApiResult { Message = Messages.MoneyIsNotEnough, Status = false };
            var now = DateTime.Now.ToUnix();
            var balance  =unit.Transactions.GetBalance(new BaseByUserDto { UserId = dto.UserId });
            if (balance >= dto.Amount)
            {
                unit.Transactions.Add(new Transaction { Amount = -dto.Amount, CreatedAt = now, Description = "ارسال پول", IsSuccessful = true, NextUserId = dto.NextUserId, TransactionCategoryId = TransactionCategories.Send.ToInt(), UserId = dto.UserId });
                unit.Transactions.Add(new Transaction { Amount = dto.Amount, CreatedAt = now, Description = "دریافت پول", IsSuccessful = true, NextUserId = dto.UserId, TransactionCategoryId = TransactionCategories.Receive.ToInt(), UserId = dto.NextUserId.Value });
                unit.Complete();
                Result.Message = Messages.OK;
                Result.Status = true;
            }
            return Result;
        }
    }
}
