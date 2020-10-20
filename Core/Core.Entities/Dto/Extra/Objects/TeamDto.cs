
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class TeamDto 
    {
        public Guid Id { get; set; }
        public UserShortDto Owner { get; set; }
        public List<UserShortDto> Members { get; set; }
        public long Date { get; set; }
        public int MaxCount { get; set; }
        public int Remained { get; internal set; }
        public bool IsMine { get; internal set; }
        public int Price { get; internal set; }
        public string Description { get; internal set; }
    }

   
}
