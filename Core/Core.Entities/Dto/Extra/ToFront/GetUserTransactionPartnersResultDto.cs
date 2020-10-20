using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetUserTransactionPartnersDto : BaseByUserDto
    {
    }
    public class GetUserTransactionPartnersResultDto : BaseApiResult
    {
        public List<UserShortDto> Object { get; set; }
    }
}
