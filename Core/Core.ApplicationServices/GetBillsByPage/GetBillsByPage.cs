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
    public class GetBillsByPage : IGetBillsByPage
    {
        private readonly IUnitOfWork unit;

        public GetBillsByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetBillsByPageResultDto Execute(BaseByUserPageBillDto dto)
        {
            return unit.Bills.GetBillsByPage(dto);            
        }
    }

    
}
