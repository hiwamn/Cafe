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
    public class PaySalary : IPaySalary
    {

        private readonly IUnitOfWork unit;

        public PaySalary(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(PaySalaryDto dto)
        {
            BaseApiResult result = new BaseApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();
            unit.Transactions.Add(new Transaction
            {
                Amount = dto.Amount,
                CreatedAt = now,
                Description = dto.Description,
                TransactionCategoryId = TransactionCategories.Salary.ToInt(),
                UserId = dto.UserId
            });
            unit.Complete();
            
            return result;
        }
    }
}
