using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum DiscountType
    {
        [Display(Description = "بدون تخفیف")]
        NoDiscount = 1,
        [Display(Description = "با تخفیف")]
        WithDiscount = 2
    }
}
