using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddWorkingTimeDto
    {
        public Guid UserId { get; set; }
        public bool IsInput { get; set; }
        public long Date { get; set; }
    }

}
