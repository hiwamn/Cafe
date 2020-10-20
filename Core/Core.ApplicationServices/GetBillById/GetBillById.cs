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
    public class GetBillById : IGetBillById
    {
        private readonly IUnitOfWork unit;

        public GetBillById(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetBillByIdResultDto Execute(BaseByIdDto dto)
        {
            BillDto bill = unit.Bills.GetBillById(dto);
            return new GetBillByIdResultDto
            {
                Object = bill,
                Status = true
            };
        }
    }

    
}
