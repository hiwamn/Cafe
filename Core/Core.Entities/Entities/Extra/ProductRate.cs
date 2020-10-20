using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ProductRate : UserBaseEntity
    {        
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid? ParentId { get; set; }
        public ProductRate Parent { get; set; }
        public List<ProductRate> Children{ get; set; }
        public int Rate { get; set; }
        public int StatusId { get; set; }
        public string Comment { get; set; }
    }
}
