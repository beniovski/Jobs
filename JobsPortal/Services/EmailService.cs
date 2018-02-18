using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace JobsPortal.Services
{
    public class EmailServices : IEmailService
    {
        public void SendEmail(string destinationEmail, string message)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(destinationEmail, "test"));
            msg.From = new MailAddress("danbed19905@gmail.com");
            msg.Body = message;

            SmtpClient spClient = new SmtpClient();

            spClient.Send(msg);
        }
    }
}