using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace FiveOathsLib.Utils
{
    public class Email
    {
        // There's some magic numbers defined here. TODO - move these to some App object for "context."
        private const string fromEmailAddress = "nick@midwaylrp.com";
        private const string fromPassword = "nmwygtyA1";

        public static void SendMail(string fromName, string toEmailAddress, string subject, string body)
        {
            MailAddress fromAddress = new MailAddress(fromEmailAddress, fromName);
            MailAddress toAddress = new MailAddress(toEmailAddress);

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }


    }
}
