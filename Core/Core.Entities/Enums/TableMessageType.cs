using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum TableMessageType
    {
        [Display(Description = "پر کردن میز")]
        Filling = 1,
        [Display(Description = "کم کردن شخص از میز")]
        Decrease = 2,
        [Display(Description = "اضافه کردن شخص به میز")]
        Increase = 3,
        [Display(Description = "فاکتور صادر شد")]
        BillCreated = 4,
        [Display(Description = "فاکتور پرداخت شد")]
        BillPaid = 5

    }
}
