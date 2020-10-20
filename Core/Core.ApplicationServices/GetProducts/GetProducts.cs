using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Utility.Tools.General;
using Utility.Tools.Notification;

namespace Core.ApplicationServices
{
    public class GetProducts : IGetProducts
    {
        private readonly IUnitOfWork unit;


        public GetProducts(IUnitOfWork unit)
        {
            this.unit = unit;

        }

        public GetProductsResultDto Execute(GetProductsDto dto)
        {
            GetProductsResultDto Result = new GetProductsResultDto { Message = Messages.OK, Status = true };
            Result.Object = unit.Products.GetProducts(dto);
            return Result;
        }
    }
}
