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
    public class GetAdminProducts : IGetAdminProducts
    {
        private readonly IUnitOfWork unit;


        public GetAdminProducts(IUnitOfWork unit)
        {
            this.unit = unit;

        }

        public GetAdminProductsResultDto Execute(GetProductsDto dto)
        {
            GetAdminProductsResultDto Result = new GetAdminProductsResultDto { Message = Messages.OK, Status = true };
            Result.Object = unit.Products.GetAdminProducts(dto);
            return Result;
        }
    }
}
