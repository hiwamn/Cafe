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
    public class GetTransactionsByPage : IGetTransactionsByPage
    {
        private readonly IUnitOfWork unit;


        public GetTransactionsByPage(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetTransactionsByPageResultDto Execute(BaseByUserPageDto dto)
        {
            List<TransactionDto> trans = unit.Transactions.GetTransactionsByPage(dto);
            return new GetTransactionsByPageResultDto
            {
                Object = trans,
                Status = true,
                Page = new PageDto
                {
                    PageNo = dto.PageNo,
                    CurrentCount = trans.Count,
                    TotalCount = unit.Transactions.GetTransactionsByPageCount(dto),
                    TotalPrice = unit.Transactions.GetTransactionsByPageTotalPrice(dto)
                }
            };
        }
    }

    
}
