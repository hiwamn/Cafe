using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Utility.Tools.SMS
{
    public enum ReceivedSMSStatusCodes
    {
        [Display(Description = "منو")]
        Menu = 0,
        [Display(Description = "منوی فیش")]
        FishMenu = 1,
        [Display(Description = "منوی دفترچه")]
        DaftarcheMenu = 2,
        [Display(Description = "منوی استحقاق درمان")]
        EstehghahMenu = 3,
        [Display(Description = "منوی سابقه")]
        SabeghehMenu = 4,
        [Display(Description = "منوی لیست")]
        ListMenu = 5,
        [Display(Description = "منوی دریافت پسورد")]
        PasswordMenu = 6,
        [Display(Description = "جواب فیش")]
        FishResult = 7,
        [Display(Description = "جواب دفترچه")]
        DaftarchehResult = 8,
        [Display(Description = "جواب استحقاق")]
        EstehghaghResult = 9,
        [Display(Description = "جواب سابقه")]
        SabeghehResult = 10,
        [Display(Description = "جواب لیست")]
        ListResult = 9,
        [Display(Description = "جواب پسورد")]
        PasswordResult = 10,
        [Display(Description = "ورود پسورد")]
        EnterPassword= 10
    }    
}
