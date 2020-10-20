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
    public class DeleteGroupGame : IDeleteGroupGame
    {

        private readonly IUnitOfWork unit;

        public DeleteGroupGame(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(BaseByIdDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.IsUsed};
            var gg = unit.GroupGames.Get(dto.Id);
            try
            {
                List<GroupGameUsers> users = unit.GroupGameUsers.GetGameUsers(dto.Id);
                users.ForEach(p =>
                {
                    unit.Transactions.Add(new Transaction
                    {
                        Amount = gg.Price,
                        CreatedAt = Agent.Now,
                        Description = "بازگشت پول بازی گروهی",
                        IsSuccessful = true,
                        TransactionCategoryId = TransactionCategories.Gateway.ToInt(),
                        UserId = p.UserId
                    });
                });
                unit.GroupGameUsers.RemoveRange(users);
                unit.Complete();
                unit.GroupGames.Remove(gg);
                unit.Complete();
                result.Status = true;
                result.Message = Messages.Success;
            }
            catch
            {
            }
            return result;
        }
    }
}
