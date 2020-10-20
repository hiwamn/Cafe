using Core.Contracts;
using Core.Entities;
using Core.Entities.Dto;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;
using Utility.Tools.Notification;

namespace Core.ApplicationServices
{
    public class ForgetPassword:IForgetPassword
    {
        private readonly IUnitOfWork unit;
        private readonly INotification notification;
        private readonly IEncrypter encrypter;

        public ForgetPassword(IUnitOfWork unit,INotification notification,IEncrypter encrypter)
        {
            this.unit = unit;
            this.notification = notification;
            this.encrypter = encrypter;
        }
       

        public BaseApiResult Execute(ForgetPasswordDto dto)
        {
            BaseApiResult result = new BaseApiResult { Message = Messages.UserNotExist };
            User user = unit.Users.GetByMobile(dto.Mobile);
            if (user != null)
            {
                var password = Agent.GenerateRandomNo(8);
                user.SetPassword(password, encrypter);
                unit.Complete();
                Task myTask = Task.Run(() => notification.SendAsync(password, dto.Mobile));
                myTask.Wait();                
                result.Message = Messages.PasswordSentBySms;
                result.Status = true;
            }

            return result;
        }
    }
}
