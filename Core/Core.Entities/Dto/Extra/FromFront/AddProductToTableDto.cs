using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddProductToTableDto
    {
        public Guid UserId { get; set; }
        public Guid TableId { get; set; }
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public int Count{ get; set; }
    }

}
