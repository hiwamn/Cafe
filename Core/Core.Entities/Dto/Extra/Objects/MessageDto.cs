
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class MessageDto
    {
        public Guid Id { get; internal set; }
        public string Text { get; internal set; }
        public Guid? UserId { get; internal set; }
        public bool IsFromAdmin { get; internal set; }
        public bool IsSeen { get; internal set; }
    }


}
