using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class ChangeReserveStatusDto
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public long? Time { get; set; }
    }

}
