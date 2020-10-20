using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class DeleteEvent : IDeleteEvent
    {

        private readonly IUnitOfWork unit;

        public DeleteEvent(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(BaseByIdDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.IsUsed};
            var ev = unit.EventAndLeagues.Get(dto.Id);
            try
            {
                List<EventUsers> users = unit.EventUsers.GetEventUsers(dto.Id);
                users.ForEach(p =>
                {
                    unit.Transactions.Add(new Transaction
                    {
                        Amount = ev.Price,
                        CreatedAt = Agent.Now,
                        Description = "بازگشت پول ایونت",
                        IsSuccessful = true,
                        TransactionCategoryId = TransactionCategories.Gateway.ToInt(),
                        UserId = p.UserId
                    });
                });
                unit.EventUsers.RemoveRange(users);
                unit.Complete();
                unit.EventAndLeagues.Remove(ev);
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

