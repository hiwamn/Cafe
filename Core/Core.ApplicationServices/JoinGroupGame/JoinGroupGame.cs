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
    public class JoinGroupGame : IJoinGroupGame
    {

        private readonly IUnitOfWork unit;
        private readonly IGetWallet getWallet;

        public JoinGroupGame(IUnitOfWork unit,IGetWallet getWallet)
        {
            this.unit = unit;
            this.getWallet = getWallet;
        }
        public ApiResult Execute(JoinGroupGameDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.AlreadyJoined, };
            var now = DateTime.Now.ToUnix();
            int Balance = getWallet.Execute(new BaseByUserDto { UserId = dto.UserId }).Object;
            if (unit.GroupGameUsers.GetByUserAndGame(new LeftGroupGameDto {UserId = dto.UserId.Value,GroupGameId = dto.GroupGameId }) == null)
            {
                GroupGameUsers ggu = new GroupGameUsers
                {
                    CreatedAt = now,
                    UserId = dto.UserId.Value,
                    GroupGameId = dto.GroupGameId
                };
                unit.GroupGameUsers.Add(ggu);
                GroupGame t = unit.GroupGames.Get(dto.GroupGameId);
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
