using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddMessageDto
    {
        public Guid UserId { get; set; }
        public Guid ToId { get; set; }
        public string Text { get; set; }
        public bool IsFromAdmin { get; set; }
    }

}
