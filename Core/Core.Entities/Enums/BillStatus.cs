using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum BillStatus
    {
        [Display(Description = "معلق")]
        Pending = 1,
        [Display(Description = "پرداخت شده با کیف پول")]
        WalletPaid = 2,
        [Display(Description = "پرداخت شده با کارت بانکی")]
        CardPaid = 3,
        [Display(Description = "پرداخت نقدی")]
        CashPaid = 4,
        [Display(Description = "تایید پرسنل برای پرداخت")]
        StaffRelease = 5
    }
}
