using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
