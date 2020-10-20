using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Tools.SMS.Rahyab
{
    public class EmailParameters
    {
        public static  string Host { get; set; }
        public static  string Username { get; set; }
        public static  string Password { get; set; }
        public static  string Port { get; set; }
        public static string TargetName { get; internal set; }
        public static string MailSender { get; internal set; }
        public static string Subject { get; internal set; }
    }
}
