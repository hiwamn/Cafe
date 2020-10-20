using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum TableStatus
    {
        [Display(Description = "آزاد")]
        Free= 1,
        [Display(Description = "در حال رزرو")]
        Reserved = 2,
        [Display(Description = "پر")]
        Taken = 3

    }
}
