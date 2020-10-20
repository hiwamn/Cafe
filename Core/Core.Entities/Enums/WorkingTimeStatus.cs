using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum WorkingTimeStatus
    {
        [Display(Description = "در دست بررسی")]
        Pending= 0,
        [Display(Description = "تایید شده")]
        Accepted = 1,
        [Display(Description = "ویرایش شده")]
        Edited = 2,
        [Display(Description = "لغو شده")]
        Canceled = 3

    }
}
