using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace JobsPortal.Services
{
    public static class EmailService 
    {
       
        public static void SendEmailConf(MailMessage message)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(message.To.ToString(), "test"));
            msg.From = new MailAddress("danbed19905@gmail.com");
            msg.Body = message.Body;

            SmtpClient spClient = new SmtpClient();

           spClient.Send(msg);

        }
    }
}