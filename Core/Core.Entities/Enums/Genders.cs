using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum Genders
    {
        [Display(Description = "نا مشخص")]
        Other = 0,
        [Display(Description = "زن")]
        Female = 1,
        [Display(Description = "مرد")]
        Male = 2
    }
}
