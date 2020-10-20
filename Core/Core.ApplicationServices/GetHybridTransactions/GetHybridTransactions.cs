using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GetHybridTransactions : IGetHybridTransactions
    {
        private readonly IUnitOfWork unit;

        public GetHybridTransactions(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public GetHybridTransactionsResultDto Execute(GetHybridTransactionsDto dto)
        {
            var obj = new List<HybridTransactionsDto> { };
            List<Transaction> trans = unit.Transactions.GetHybridTransactions(dto);
            var res = trans?.GroupBy(p => p.CreatedAt.PersianYear().ToString() + p.CreatedAt.PersianMonth().ToString()).ToList();
            if (res != null)
            {
                res.ForEach(p =>
                {
                    HybridTransactionsDto tmp = new HybridTransactionsDto { Date = p.FirstOrDefault().CreatedAt };
                    tmp.Income = p.Where(p => p.Amount>=0).ToList().Sum(q => q.Amount);
                    tmp.Outcome = p.Where(p => p.Amount <= 0).ToList().Sum(q => q.Amount);
                    obj.Add(tmp);
                });
            }
            return new GetHybridTransactionsResultDto
            {
                Object = obj,
                Status = true
            };
        }
    }


}
