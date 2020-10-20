using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum TransactionType
    {
        [Display(Description = "درگاه")]
        Gateway = 4,
        [Display(Description = "دریافت")]
        Receive = 2,
        [Display(Description = "نقدی")]
        Cash = 5,
        [Display(Description = "برداشت از حساب")]
        Pay = 1


    }
}
