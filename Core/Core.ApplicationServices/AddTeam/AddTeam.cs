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
    public class AddTeam : IAddTeam
    {

        private readonly IUnitOfWork unit;
        private readonly IGetWallet getWallet;

        public AddTeam(IUnitOfWork unit, IGetWallet getWallet)
        {
            this.unit = unit;
            this.getWallet = getWallet;
        }
        public ApiResult Execute(AddTeamDto dto)
        {

            ApiResult result = new ApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();
            int Balance = getWallet.Execute(new BaseByUserDto { UserId = dto.UserId }).Object;
            var teamPrice = int.Parse(unit.Setting.GetAll().FirstOrDefault(p => p.Name == "TeamPrice").Value);

            if (Balance < teamPrice)
            {
                result.Message = Messages.MoneyIsNotEnough;
            }
            else
            {
                Team team = new Team
                {
                    Date = dto.Date,
                    CreatedAt = now,
                    MaxCount = dto.MaxCount,
                    UserId = dto.UserId.Value,
                    Remained = dto.MaxCount,
                    Description = dto.Description
                };
                unit.Transactions.Add(new Transaction
                {
                    Amount = -teamPrice,
                    CreatedAt = now,
                    IsSuccessful = true,
                    UserId = dto.UserId.Value,
                    TransactionCategoryId = TransactionCategories.BillPay.ToInt()
                });
                unit.Team.Add(team);
                unit.Complete();
            }

            return result;
        }
    }
}
