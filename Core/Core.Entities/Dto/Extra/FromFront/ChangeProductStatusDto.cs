using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class ChangeProductStatusDto
    {
        public Guid Id { get; set; }
        public int StatusId { get; set; }
    }
}
