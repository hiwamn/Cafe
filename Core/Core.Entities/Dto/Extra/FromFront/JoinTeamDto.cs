using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class JoinTeamDto : BaseByUserDto
    {
        public Guid TeamId{ get; set; }        
    }

}
