
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class OrderDto
    {
        public long CreatedAt { get; internal set; }
        public long UpdatedAt { get; internal set; }
        public UserDto User { get; set; }
        public TableDto Table{ get; set; }
        public List<BillItemDto> Items{ get; set; }
        public string Description { get; internal set; }
        public long EndedAt { get; internal set; }
        public Guid Id { get; internal set; }        
        public int StatusId { get; internal set; }
    }


}
