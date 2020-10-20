using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum ProductStatus
    {
        [Display(Description = "فعال")]
        Active= 1,
        [Display(Description = "غیرفعال")]
        Deactive= 2

    }
}
