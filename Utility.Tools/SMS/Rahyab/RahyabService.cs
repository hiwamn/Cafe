using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

using Utility.Tools.Notification;
using System.Collections;

namespace Utility.Tools.SMS.Rahyab
{
    public class RahyabService : INotification
    {
        private readonly IConfiguration configuration;

        public RahyabService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> CheckDeliveryAsync(string FollowingCode)
        {
            configuration.GetSection<RahyabParameters>();
            Cls_SMS.ClsStatus sms = new Cls_SMS.ClsStatus();
            ArrayList Arr_Res = new ArrayList();
            Arr_Res = await sms.GetSMSStatusAsync(FollowingCode);

            for (int i = 0; i < Arr_Res.Count; i++)
            {
                Cls_SMS.ClsStatus.STC_SMSStatus tt = (Cls_SMS.ClsStatus.STC_SMSStatus)Arr_Res[i];
                if (!tt.DeliveryStatus.ToLower().Contains("delivered"))
                {
                    if (tt.DeliveryStatus.ToLower().Contains("error"))//Check_Error  پیامک توسط سرور دریافت نشده است. )ریزش/لیست سیاه( 6
                        return SentSMSStatusCodes.BlackList.ToInt();
                    if (tt.DeliveryStatus.ToLower().Contains("check"))   //Check_OK  پیامک به مخابرات ارسال شده است 2
                        return SentSMSStatusCodes.CheckOK.ToInt();
                    if (tt.DeliveryStatus.ToLower().Contains("fail"))   //SMS_Failed  در ارسال پیامک خطا رخ داده است. 7
                        return SentSMSStatusCodes.Failed.ToInt();
                    if (tt.DeliveryStatus.ToLower().Contains("reject"))   //  REJECTED  پیامک توسط درگاه پذیرفته نشده است. )ریزش/لیست سیاه( 8
                        return SentSMSStatusCodes.Rejected.ToInt();
                    return SentSMSStatusCodes.Unknown.ToInt();
                }
            }
            return SentSMSStatusCodes.Delivered.ToInt();

        }

        public async Task<long> GetBalance()
        {
            configuration.GetSection<RahyabParameters>();
            Cls_SMS.ClsGetRemain gr = new Cls_SMS.ClsGetRemain();
            return gr.GetRemainCredit();
        }

        public async Task<string> SendAsync(string Text, string Destination)
        {
            configuration.GetSection<RahyabParameters>();
            Cls_SMS.ClsSend sms_Single = new Cls_SMS.ClsSend();
            var a = sms_Single.SendSMS_Single(Text, Destination);
            if(a[1] == "0")
                return null;
            return a[1];            
        }
    }
}




