using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum BarginTypes
    {
        [Display(Description = "درصد")]
        Percent = 1,
        [Display(Description = "ثابت")]
        Fixed = 2
    }
}
