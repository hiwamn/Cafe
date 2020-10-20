using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ChangeProductStatus : IChangeProductStatus
    {
        private readonly IUnitOfWork unit;

        public ChangeProductStatus(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public BaseApiResult Execute(ChangeProductStatusDto dto)
        {
            BaseApiResult result = new BaseApiResult { Status = true, Message = "کاربر یافت نشد" };

            Product res = unit.Products.Get(dto.Id);
            res.StatusId = dto.StatusId;
            unit.Complete();
            return result;
        }
    }
}
