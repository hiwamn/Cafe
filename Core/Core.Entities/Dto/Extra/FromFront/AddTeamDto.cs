using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddTeamDto : BaseByUserDto
    {
        public long Date { get; set; }
        public int MaxCount{ get; set; }
        public string Description { get; set; }
    }

}
