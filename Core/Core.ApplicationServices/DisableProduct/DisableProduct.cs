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
    public class DisableProduct : IDisableProduct
    {

        private readonly IUnitOfWork unit;

        public DisableProduct(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public BaseApiResult Execute(DisableProductDto dto)
        {

            BaseApiResult result = new BaseApiResult { Status = true, Message = Messages.Success, };
            var now = DateTime.Now.ToUnix();
            var mess = unit.Products.Get(dto.ProductId);
            mess.StatusId = dto.Status.ToInt();
            unit.Complete();


            return result;
        }
    }
}
