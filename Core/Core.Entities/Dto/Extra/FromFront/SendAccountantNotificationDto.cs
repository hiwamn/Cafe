using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class SendAccountantNotificationDto
    {
        public int Type{ get; set; }        
        public Guid TableId{ get; set; }        
    }

}
