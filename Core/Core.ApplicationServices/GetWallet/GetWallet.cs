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
    public class GetWallet : IGetWallet
    {
        private readonly IUnitOfWork unit;

        public GetWallet(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetWalletResultDto Execute(BaseByUserDto dto)
        {
                                    
            return new GetWalletResultDto
            {
                Object = unit.Transactions.GetBalance(dto),
                Status = true
            };
        }
    }

    
}
