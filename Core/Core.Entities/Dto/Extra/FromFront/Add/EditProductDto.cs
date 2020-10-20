using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class EditProductDto
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StatusId { get; set; }
        public List<Guid> Images{ get; set; }
        public int StaffPrice { get; set; }
    }
}
