using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum UserType
    {
        [Display(Description = "مدیر")]
        Admin = 1,
        [Display(Description = "کاربر")]
        User = 2,
        [Display(Description = "پرسنل")]
        Staff = 3,
        [Display(Description = "حسابدار")]
        Accountant = 4

    }
}
