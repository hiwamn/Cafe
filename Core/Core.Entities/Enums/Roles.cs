using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Enums
{
    public enum Roles
    {
        [Display(Description = "کاربر")]
        User = 1,
        [Display(Description = "ادمین")]
        Admin = 2,
        [Display(Description = "پرسنل")]
        Staff = 3,
        [Display(Description = "حسابدار")]
        Accountant = 4,
        [Display(Description = "رزرو")]
        Reserve = 5,
    }
}
