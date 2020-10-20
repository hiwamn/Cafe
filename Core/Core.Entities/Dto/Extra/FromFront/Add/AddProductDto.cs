using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<Guid> Images{ get; set; }
        public int StaffPrice { get; set; }
    }
}
