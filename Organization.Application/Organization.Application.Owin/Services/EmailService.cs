using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Owin.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Credentials:
            //  var credentialUserName = ConfigurationManager.AppSettings["emailFrom"];
            //   var sentFrom = ConfigurationManager.AppSettings["emailFrom"];
            //   var pwd = ConfigurationManager.AppSettings["emailPassword"];

            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress("Support@RightFares.com");
            mailMessage.To.Add(new MailAddress(message.Destination));
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;

            // Configure the client:
            SmtpClient client = new SmtpClient();
            client.EnableSsl = false;
            client.UseDefaultCredentials = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("Support@RightFares.com", "Lattakia1972");
            client.Host = "smtpout.secureserver.net";
            client.Port = 3535;

            // Send:
            return client.SendMailAsync(mailMessage);
        }
    }
}
