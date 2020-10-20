using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum EntityStatus
    {
        [Display(Description = "فعال")]
        Active = 1,
        [Display(Description = "تایید شده")]
        Confirmed = 2,
        [Display(Description = "بلوکه شده")]
        Blocked = 3,
        [Display(Description = "حذف شده")]
        Deleted = 4

    }
}
