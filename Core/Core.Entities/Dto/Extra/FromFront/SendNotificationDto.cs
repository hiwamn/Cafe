using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class SendNotificationDto
    {
        public Guid? UserId { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
    }

}
