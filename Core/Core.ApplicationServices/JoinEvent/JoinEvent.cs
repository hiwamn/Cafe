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
    public class JoinEvent : IJoinEvent
    {

        private readonly IUnitOfWork unit;
        private readonly IGetWallet getWallet;

        public JoinEvent(IUnitOfWork unit,IGetWallet getWallet)
        {
            this.unit = unit;
            this.getWallet = getWallet;
        }
        public ApiResult Execute(JoinEventDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.AlreadyJoined, };
            var now = DateTime.Now.ToUnix();
            int Balance = getWallet.Execute(new BaseByUserDto { UserId = dto.UserId }).Object;
            if (unit.EventUsers.GetByUserAndEvent(dto) == null)
            {
                EventUsers ev = new EventUsers
                {
                    CreatedAt = now,
                    UserId = dto.UserId.Value,
                    EventAndLeagueId = dto.EventAndLeagueId
                };
                unit.EventUsers.Add(ev);
                EventAndLeague t = unit.EventAndLeagues.Get(dto.EventAndLeagueId);
                t.RemainedCount--;
                var pr = t.DiscountPrice == null ? t.Price : t.DiscountPrice.Value;
                if (Balance < pr)
                {
                    result.Message = Messages.MoneyIsNotEnough;
                }
                else
                {
                    unit.Transactions.Add(new Transaction
                    {
                        Amount = -pr,
                        CreatedAt = now,
                        IsSuccessful = true,
                        UserId = dto.UserId.Value,
                        TransactionCategoryId = TransactionCategories.BillPay.ToInt()
                    });
                    unit.Complete();
                    result.Status = true;
                    result.Message = Messages.Success;
                }
            }
            return result;
        }
    }
}
