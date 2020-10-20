
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class UserLastVisitTimeDto
    {
        public UserShortDto User { get; set; }
        public TimeSpan Time{ get; set; }
    }
}
