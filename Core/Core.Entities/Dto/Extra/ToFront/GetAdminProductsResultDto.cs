using System;
using System.Collections.Generic;

namespace Core.Entities.Dto
{
    public class GetAdminProductsDto
    {
        public Guid? ParentId { get; set; }
        public bool IncludeChildren { get; set; }
    }
    public class GetAdminProductsResultDto : BaseApiResult
    {
        public List<AdminProductDto> Object { get; set; }
    }
}
