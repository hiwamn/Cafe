using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Utility.Tools.SMS
{
    public enum SentSMSStatusCodes
    {
        [Display(Description = "تازه ثبت شده")]
        Pending = 0,
        [Display(Description = "در انتظار دلیوری")]
        WaitingForDelivery = 1,
        [Display(Description = "تحویل مخابرات")]
        CheckOK = 2,
        [Display(Description = "شماره اشتباه")]
        WrongNumber = 3,
        [Display(Description = "نامشخص")]
        Nothing1 = 4,
        [Display(Description = "دلیور شده")]
        Delivered = 5,
        [Display(Description = "لیست سیاه")]
        BlackList = 6,
        [Display(Description = "خطا در راسال")]
        Failed = 7,
        [Display(Description = "رد شده")]
        Rejected = 8,
        [Display(Description = "خطای نامشخص")]
        Unknown = 9,
        [Display(Description = "خطای نامشخص")]
        DB = 15
    }    
}
