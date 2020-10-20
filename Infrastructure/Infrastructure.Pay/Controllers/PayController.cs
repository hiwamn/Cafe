using Microsoft.AspNetCore.Mvc;
using System;
using Pay.Models;
using Core.Contracts;
using Utility.Tools.General;
using Core.Entities.GlobalSettings;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Core.Entities.Dto;
using Zarinpal;
using Enums;
using Core.ApplicationServices;

namespace Infrastructure.Pay.Controllers
{

    
    public class PayController : Controller
    {
        //http://localhost:5555/?param=y7N2S5e67781l3l3o1L920J!m0f0B015S!d6a772K4z7K1J8w802N1/////////////////////////////////////////////////

        private readonly IUnitOfWork unit;
        private readonly IConfiguration configuration;
        private readonly IJoinEvent joinEvent;
        private readonly IJoinGroupGame  joinGroupGame;
        private readonly IJoinTeam joinTeam;
        private readonly IAddTeam addTeam;
        public string Link = "";
        public string Merchant = "";

        public PayController(
            IUnitOfWork unit, 
            IConfiguration configuration,
            IJoinEvent  joinEvent,
            IJoinGroupGame joinGroupGame,
            IJoinTeam joinTeam,
            IAddTeam addTeam

            )
        {
            this.unit = unit;
            this.configuration = configuration;
            this.joinEvent = joinEvent;
            this.joinGroupGame = joinGroupGame;
            this.joinTeam = joinTeam;
            this.addTeam = addTeam;
        }

        [HttpPost]
        public async Task<ApiResult> StartPay([FromBody] PaymentModel model)
        {
            
            //return new ApiResult { Message = Agent.ToJson(model)};
            var result = new ApiResult { Status = false, Message = Messages.GatewayError };
            
            
            configuration.GetSection<PaymentData>();
            Merchant = PaymentData.Account;



            var Authority = await CreateLinkAsync(model);

            if (Authority != null && Authority != "")
            {
                if (!unit.Transactions.IsAuthorityExist(Authority))
                {
                    unit.Transactions.Add(new Transaction
                    {
                        Amount = model.Amount,
                        Authority = Authority,
                        CreatedAt = DateTime.Now.ToUnix(),
                        UserId = model.UserId,
                        TransactionCategoryId = TransactionCategories.Gateway.ToInt(),
                        Json = model.Json,
                        Type = model.Type
                    });
                    unit.Complete();
                    result.Status = true;
                    result.Object = Link;
                }
                else
                    result.Message = Messages.AuthorityExist;
            }



            return result;

        }
        public async Task<IActionResult> MobileVerify(string Status, string Authority)
        {
            return await VerifyProcess(Status, Authority);
        }
        public async Task<IActionResult> WebVerify(string Status, string Authority)
        {
            return await VerifyProcess(Status, Authority);
        }
        public IActionResult BadPrice()
        {
            return View();
        }


        [NonAction]
        private async Task<string> CreateLinkAsync(PaymentModel model)
        {

            Payment pay = new Payment(Merchant, model.Amount);

            var result = !model.IsWeb ? await pay.PaymentRequest(PaymentData.Title, PaymentData.MobileAddress, PaymentData.Email, model.Mobile)
                : await pay.PaymentRequest(model.NationalCode, PaymentData.WebAddress, PaymentData.Email, model.Mobile);

            string Authority = null;
            if (result != null)
            {
                Link = result.Link;
                Authority = result.Authority;
            }
            else
                ResetModel(model);
            return Authority;
        }
        [NonAction]
        private async Task<IActionResult> VerifyProcess(string Status, string Authority)
        {
            configuration.GetSection<PaymentData>();
            PaymentModel model = new PaymentModel();
            if (Status != null && Authority != null)
            {
                Transaction transaction = unit.Transactions.GetByAuthority(Authority);
                if (transaction == null)
                    model.Message = "محصول وجود ندارد";
                else if (transaction.IsSuccessful)
                    model.Message = "این کد پیگیری قبلا ذخیره شده است";
                else
                {
                    var pay = new Payment(PaymentData.Account, transaction.Amount);
                    var result = await pay.Verification(Authority);
                    if (result != null)
                    {
                        transaction.RefId = result.RefId.ToString();
                        var state = result.Status;
                        if (Status == "OK")
                        {
                            model.Amount = transaction.Amount;
                            transaction.IsSuccessful = true;
                            model.Message = "پرداخت شما با موفقیت انجام شد";
                        }
                        else if (Status.ToString() == "NOK")
                        {
                            transaction.IsSuccessful = false;
                            model.Message = GetErrorMessage(state);
                            transaction.Description = model.Message;
                        }
                        unit.Complete();
                        if (transaction.Type != 0 && Status == "OK")
                        {
                            switch ((EntityType)transaction.Type)
                            {
                                case EntityType.Event:
                                    joinEvent.Execute(Agent.FromJson<JoinEventDto>(transaction.Json));
                                    break;
                                case EntityType.GroupGame:
                                    joinGroupGame.Execute(Agent.FromJson<JoinGroupGameDto>(transaction.Json));
                                    break;
                                //case EntityType.BeMyTeamMate:
                                //    joinTeam.Execute(Agent.FromJson<JoinTeamDto>(transaction.Json));
                                //    break;
                                case EntityType.AddTeam:
                                    addTeam.Execute(Agent.FromJson<AddTeamDto>(transaction.Json));
                                    break;
                            }
                        }
                        
                    }
                    else
                        ResetModel(model);
                }
            }
            return View(model);
        }

        
        [NonAction]
        private void ResetModel(PaymentModel model)
        {
            model.Message = "پارامترها غلط است";
        }
        [NonAction]
        internal static string GetErrorMessage(int state)
        {
            switch (state)
            {
                case -1:
                    return "اطلاعات ارسال شده ناقص است";
                case -2:
                    return "IP و يا مرچنت كد پذيرنده صحيح نيست";
                case -3:
                    return "با توجه به محدوديت هاي شاپرك امكان پرداخت با رقم درخواست شده ميسر نمي باشد";
                case -4:
                    return "سطح تاييد پذيرنده پايين تر از سطح نقره اي است";
                case -11:
                    return "درخواست مورد نظر يافت نشد";
                case -12:
                    return "امكان ويرايش درخواست ميسر نمي باشد";
                case -21:
                    return " نوع عمليات مالي براي اين تراكنش يافت نشد";
                case -22:
                    return "تراكنش نا موفق مي باشد";
                case -33:
                    return "رقم تراكنش با رقم پرداخت شده مطابقت ندارد";
                case -34:
                    return "سقف تقسيم تراكنش از لحاظ تعداد يا رقم عبور نموده است";
                case -40:
                    return "اجازه دسترسي به متد مربوطه وجود ندارد";
                case -41:
                    return "اطلاعات ارسال شده مربوط به AdditionalData غيرمعتبر مي باشد";
                case -42:
                    return " زمان معتبر طول عمر  شناسه  پرداخت بايد بين 30دقيه تا 45روز مي باشد";
                case -54:
                    return "درخواست مورد نظر آرشيو شده است";
                case 99:
                    return "عمليات با موفقيت انجام گرديده است";
                case 100:
                    return "عمليات با موفقيت انجام گرديده است";
                case 101:
                    return "عمليات پرداخت موفق بوده وقبلا تراكنش انجام شده است";
                default:
                    return "خطای ناشناخته";
            }
        }
    }
}