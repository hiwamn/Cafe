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
    public class GetUserTransactionPartners : IGetUserTransactionPartners
    {
        private readonly IUnitOfWork unit;

        public GetUserTransactionPartners(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetUserTransactionPartnersResultDto Execute(BaseByUserDto dto)
        {
            List<UserShortDto> users = unit.UserTransactionList.GetUserTransactionPartners(dto);
            return new GetUserTransactionPartnersResultDto
            {
                Object = users,
                Status = true,
                
            };
        }
    }

    
}
