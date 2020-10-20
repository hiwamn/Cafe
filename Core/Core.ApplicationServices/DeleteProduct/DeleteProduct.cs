using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class DeleteProduct : IDeleteProduct
    {

        private readonly IUnitOfWork unit;

        public DeleteProduct(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public ApiResult Execute(BaseByIdDto dto)
        {
            ApiResult result = new ApiResult { Status = false, Message = Messages.IsUsed };

            var gt = unit.Products.Get(dto.Id);
            try
            {
                unit.Products.Remove(gt);
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
