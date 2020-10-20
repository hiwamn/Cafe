using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System;

using Utility.Tools.Notification;

namespace Utility.Tools.SMS.Rahyab
{
    public class EmailService : INotification
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<int> CheckDeliveryAsync(string FollowingCode)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetBalance()
        {
            throw new NotImplementedException();
        }

        public async Task<string> SendAsync(string Text, string Destination)
        {
            configuration.GetSection<EmailParameters>();
            var client = new SmtpClient(EmailParameters.Host, EmailParameters.Port.ToInt())
            {
                //UseDefaultCredentials = false,
                Credentials = new NetworkCredential(EmailParameters.Username, EmailParameters.Password),
                TargetName = EmailParameters.TargetName,
                EnableSsl = true
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(EmailParameters.MailSender)
            };
            mailMessage.To.Add(Destination);
            mailMessage.Subject = EmailParameters.Subject;
            mailMessage.Body = Text;

            
            await client.SendMailAsync(mailMessage);

            return null;
        }        
    }
}
