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
    public class GetOrdersByPage : IGetOrdersByPage
    {
        private readonly IUnitOfWork unit;

        public GetOrdersByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetOrdersByPageResultDto Execute(GetOrdersByPageDto dto)
        {
            return unit.Bills.GetOrdersByPage(dto);            
        }
    }

    
}
