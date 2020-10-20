using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetHybridTransactionsDto : BaseByUserDto    
    {        
    }
    public class GetHybridTransactionsResultDto : BaseApiResult
    {
        public List<HybridTransactionsDto> Object { get; set; }
    }

    

    public class HybridTransactionsDto
    {
        public int Income { get; set; }
        public int Outcome{ get; set; }
        public long Date { get; set; }        
    }
}
