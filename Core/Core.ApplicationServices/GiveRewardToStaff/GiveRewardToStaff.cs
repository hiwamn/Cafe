using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Functions;
using Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GiveRewardToStaff : IGiveRewardToStaff
    {
        private readonly IUnitOfWork unit;

        public GiveRewardToStaff(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(GiveRewardToStaffDto dto)
        {   
            var now = Agent.UnixTimeNow();

            unit.Transactions.Add(new Transaction
            {
                UserId = dto.UserId,
                Amount = dto.Amount,
                CreatedAt = now,
                Description = dto.Description,
                IsSuccessful = true,
                TransactionCategoryId = TransactionCategories.IncreaseDailyCredit.ToInt(),
            });
            unit.Complete();
            
            return new BaseApiResult {Status = true };
        }
    }
}
