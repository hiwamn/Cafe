using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetWalletDto : BaseByUserDto
    {
    }
    public class GetWalletResultDto : BaseApiResult
    {
        public int Object { get; set; }
    }

    public class GetTransactionsByPageDto : BaseByUserDto
    {
    }
    public class GetTransactionsByPageResultDto : BaseApiPageResult
    {
        public List<TransactionDto> Object { get; set; }
    }
}
