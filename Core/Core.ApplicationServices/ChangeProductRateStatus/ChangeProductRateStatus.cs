using Core.Contracts;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ChangeProductRateStatus : IChangeProductRateStatus
    {
        private readonly IUnitOfWork unit;

        public ChangeProductRateStatus(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public ApiResult Execute(ChangeProductRateStatusDto dto)
        {
            ApiResult result = new ApiResult { Status = true, Message = "کاربر یافت نشد" };

            var productRate = unit.ProductRate.Get(dto.Id);
            productRate.StatusId = dto.StatusId;
            unit.Complete();
            return result;
        }
    }
}
