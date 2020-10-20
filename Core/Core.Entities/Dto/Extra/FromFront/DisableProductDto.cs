using Enums;
using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class DisableProductDto
    {
        public Guid ProductId { get; set; }
        public ProductStatus Status { get; set; }
    }

}
