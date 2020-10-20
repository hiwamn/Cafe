using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum ProductRateStatus
    {
        [Display(Description = "معلق")]
        Pending= 0,
        [Display(Description = "فعال")]
        Active= 1,
        [Display(Description = "غیرفعال")]
        Deactive= 2,
        [Display(Description = "حذف شده")]
        Deleted= 3

    }
}
