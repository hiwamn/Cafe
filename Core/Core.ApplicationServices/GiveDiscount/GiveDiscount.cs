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
    public class GiveDiscount : IGiveDiscount
    {

        private readonly IUnitOfWork unit;

        public GiveDiscount(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(GiveDiscountDto dto)
        {
            BaseApiResult result = new BaseApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();
            unit.UserDiscount.Add(new UserDiscount
            {
                CreatedAt = now,
                UserId = dto.UserId,
                From = dto.From,
                To = dto.To,
                Percent = dto.Percent
            });
            unit.Complete();
            
            return result;
        }
    }
}
