using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum TransactionCategories
    {
        [Display(Description = "پرداخت")]
        BillPay = 1,
        [Display(Description = "دریافت")]
        Receive = 2,
        [Display(Description = "ارسال")]
        Send = 3,
        [Display(Description = "واریز از درگاه")]
        Gateway = 4,
        [Display(Description = "پرداخت نقدی")]
        Cash = 5,
        [Display(Description = "افزایش روزانه")]
        IncreaseDailyCredit = 6,
        [Display(Description = "کاهش روزانه")]
        DecreaseDailyCredit = 7,
        [Display(Description = "حقوق")]
        Salary = 8

    }
}

//{ Id = 6, Name = "افزایش اعتبار روزانه" });
//{ Id = 7, Name = "کاهش اعتبار روزانه" });


