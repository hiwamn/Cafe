using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetProductRatesByPage : IGetProductRatesByPage
    {
        private readonly IUnitOfWork unit;

        public GetProductRatesByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetProductRatesByPageResultDto Execute(GetProductRatesByPageDto dto)
        {
            return unit.ProductRate.GetProductRatesByPage(dto);
        }
    }

    
}
