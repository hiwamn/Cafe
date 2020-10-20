using Enums;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class EditWorkingTimeDto
    {
        public Guid Id{ get; set; }
        public double Hour{ get; set; }
        public WorkingTimeStatus Status{ get; set; }
    }

}
