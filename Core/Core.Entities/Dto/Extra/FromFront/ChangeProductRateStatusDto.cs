using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class ChangeProductRateStatusDto
    {
        public Guid Id { get; set; }        
        public int StatusId { get; set; }
    }

}
