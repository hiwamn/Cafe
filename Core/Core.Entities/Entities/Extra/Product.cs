using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public virtual Product Parent { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StaffPrice { get; set; }
        public int StatusId { get; set; }
        public virtual EntityStatus Status { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<Product> Children{ get; set; }
        public virtual List<BillItem> BillItem { get; set; }
        public virtual List<ProductRate> ProductRate { get; set; }
    }
}
