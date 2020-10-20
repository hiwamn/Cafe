using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class ChangeUserReserveAccessDto
    {
        public Guid UserId { get; set; }        
        public bool CanReserve{ get; set; }        
    }

}
