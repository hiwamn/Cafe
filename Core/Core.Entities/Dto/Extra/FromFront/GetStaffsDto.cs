using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetStaffsDto 
    {

    }
    public class GetStaffsResultDto : BaseApiResult
    {
        public List<UserDto> Object { get; set; }
    }

    
}
