using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organization.Application.DTO.Entities;
using Microsoft.Practices.ServiceLocation;
using Organization.Application.Business.Interface;
using System.Net.Mail;

namespace Organization.Application.Business.Email
{
    public class EmailClient : IEmailClient
    {
        public Task SendEmailConfirmation(string userId, string subject, string body)
        {
            //var accountBL = ServiceLocator.Current.GetInstance<IAccountBL>();

            //EmailTemplate emailTemplate = accountBL.GetEmail("EMAIL_VERIFICATION");
 
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.IsBodyHtml = true;
            //mailMessage.From = new MailAddress("Support@RightFares.com");
            //mailMessage.To.Add(new MailAddress(person.PrimaryEmail));
            //mailMessage.Subject =emailTemplate.Subject;
            //mailMessage.Body = body;

            //SmtpClient client = new SmtpClient();
            //client.EnableSsl = false;
            //client.UseDefaultCredentials = true;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.Credentials = new System.Net.NetworkCredential("Support@RightFares.com", "Lattakia1972");
            //client.Host = "smtpout.secureserver.net";
            //client.Port = 3535;
            //client.Send(mailMessage);

           return Task.FromResult(0);
        }
    }
}
