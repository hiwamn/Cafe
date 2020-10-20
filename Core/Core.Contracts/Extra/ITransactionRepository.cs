using Core.Entities;
using Core.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        int GetBalance(BaseByUserDto dto);
        List<TransactionDto> GetTransactionsByPage(BaseByUserPageDto dto);
        int GetTransactionsByPageCount(BaseByUserPageDto dto);
        long GetTransactionsByPageTotalPrice(BaseByUserPageDto dto);
        bool IsAuthorityExist(string authority);
        Transaction GetByAuthority(string authority);
        List<Transaction> GetHybridTransactions(GetHybridTransactionsDto dto);
        List<Transaction> GetLastYear(long lastYear);
    }
}
