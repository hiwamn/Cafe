using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.General
{
    public class Messages
    {
        public static string LimitExceeded { get; set; } = "شما تا 15 دقیقه دیگر قادر به ارسال نیستید";
        public static string NumOfProductExceeded { get; set; } = "شما با محدودیت ثبت آگهی از این نوع مواجه شده اید";
        public static string VisaReady { get; set; } = "تبریک! کد پیگیری شما در فایل سفارت وجود دارد";
        public static string VisaNotReady { get; set; } = "متاسفانه کد پیگیری شما در فایل سفارت وجود ندارد";

        public static string CodeNotExist { get; set; } = "این کد وجود ندارد";

        public static string UserIsExist { get; set; } = "این کاربر وجود دارد";

        public static string UserNotExist { get; set; } = "این کاربر وجود ندارد";
        public static string WrongCode { get; set; } = "کد نادرست است";
        public static string NoUpdateRaw { get; set; } = "There is no Update";
        public static string VisaCodeExist { get; set; } = "شما از این نوع کد ذخیره کرده اید";
        public static string PasswordSentBySms { get; set; } = "رمز شما با پیامک ارسال شد";
        public static string UserNotActivated { get; set; } = "کاربر  فعال نشده است";
        public static string OK { get; set; } = "عملیات با موفقیت انجام شد";
        public static string InvalidPassword { get; set; } = "رمز عبور نادرست است";
        public static string CanNotRegisterAnotherTest { get; set; } = "شما از کد تست خود استفاده کرده اید";
        public static string ProductNotExist { get; set; } = "محصول وجود ندارد";
        public static string ProductIsExist { get; set; } = "محصول قبلا نشان گذاری شده است";
        public static string Success { get; set; } = "درخواست با موفقیت انجام شد";
        public static string NotRelatedUser { get; set; } = "این درخواست به نام کاربری شما تعلق ندارد";
        public static string NotOK { get; set; } = "کد نادرست است";
        public static string AccessDenied { get; set; } = "شما سطح دسترسی لازم برای مشاهده این بخش را ندارید";
        public static string SpecialtyIsExist { get; set; } = "This specialty has been added";
        public static string SpecialtyNotExist { get; set; } = "This specialty is not exist";
        public static string RateIsExist { get; set; } = "This user has registered rate for this doctor";
        public static string VideoNotExist { get; set; }  = "This video is not exist";
        public static string ArticleNotExist { get; set; } = "This article is not exist";
        public static string PendingQuestionIsExist { get; set; } = "You have a pending message";
        public static string AlreadyFollowed { get; set; } = "You have already followed this doctor";
        public static string DoctorAlreadyAdded { get; set; } = "You have already added this doctor";
        public static string ServiceAlreadyAdded { get; set; } = "You have already added this service";
        public static string PendingAppointmentIsExist { get; set; } = "You have already a pending appointment";

        public static string PasswordIsChanged { get; set; } = "رمز عبور تغییر کرد";
        public static string DeletedSuccessfully { get; set; } = "با موفقیت حذف شد";
        public static string PleaseSendImage { get; set; } = "Please send your image";
        public static string PleaseWaitForCheckingTheImage { get; set; } = "Please wait. You image has not been checked";
        public static string ImageHasBeenRejected { get; set; } = "Please send another image. Your image has been rejected";
        public static string SomeUsersUse { get; set; } = "You can not delete this object. Some users use it";
        public static string IsUsed { get; set; } = "از این آبجکت استفاده شده است";
        public static string TicketNotExist { get; set; } = "این تیکت وجود ندارد";
        public static string GatewayError { get; set; } = "مشکل در ارتباط با درگاه";
        public static string AuthorityExist { get; set; } = "این کد پرداخت وجود دارد";
        public static string ObjectNotExist { get; set; } = "این داده وجود ندارد";
        public static string InvalidRegistrationCode { get; set; } = "این کد مشاور نادرست است";
        public static string HasPendingProcess { get; set; } = "شما نمی توانید درخواست دیگری ثبت کنید. لطفا تا پاسخ دهی درخواست های دیگر صبور باشید";
        public static string IncorrectOldPassword { get; set; } = "رمز عبور قبلی نادرست است.";
        public static string KargahExist { get; set; } = "این کارگاه وجود دارد";
        public static string NationalCodeIsExistForAnotherNumber { get; set; } = "این کد ملی قبلا برای شماره * استفاده شده است";
        public static string ProcessHasBeenTaken { get; set; } = "این درخواست قبلا توسط کاربر دیگری پیگیری شده است";
        public static string AlreadyJoined { get; set; } = "شما قبلا عضو شده اید";
        public static string ObjectChaned { get; set; } = "تغییرات اعمال شد.";
        public static string MoneyIsNotEnough { get; set; } = "موجودی کافی نیست. لطفا حساب خود را شارژ کنید";
        public static string AccessDeniedFor3LoginAttemt { get; set; } = "شما به دلیل 3 لاگین ناموق در یک ساعت گذشته قادر به لاگین نیستید";
        public static string AccessDeniedFor5LoginAttemt { get; set; } = "شما به دلیل 5 لاگین ناموق اجازه دسترسی به سامانه را ندارید. لطفا با پشتیبانی تماس بگیرید";
        public static string NationalCodeIsUsed { get; set; } = "از این کد ملی استفاده شده است";
        public static string MobileIsUsed { get; set; } = "از این موبایل استفاده شده است";
        public static string InvalidBarCode { get; set; } = "این بار کد نادرست است";
        public static string TableHasBeenTaken { get; set; } = "این میز قبلا رزرو شده است";
        public static string NationalCodeNotExist { get; set; } = "این کد ملی ثبت نام نکرده است";
        public static string DailyLevelExceeded { get; set; } = "بیش از حد تراکنش روزانه نمیتوانید خرید کنید";
        public static string BillNotFound { get; set; } = "فاکتور یافت نشد";
        public static string ProcessNotExist { get; set; } = "این درخواست وجود ندارد";
        public static string BillStatusIsChanged { get; set; } = "وضعیت فاکتور با موفقیت تغییر کرد";
    }
}
