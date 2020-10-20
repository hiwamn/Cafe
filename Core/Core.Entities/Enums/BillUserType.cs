using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum BillUserType
    {
        [Display(Description = "کاربر ثبت شده")]
        RegisterUser = 1,
        [Display(Description = "کاربر میهمان")]
        GuestUser = 2
    }
}
