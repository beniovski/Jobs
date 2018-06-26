using System;
using System.IO;
using System.Net.Mail;
using System.Web;

namespace JobsPortal.Services
{
    public class EmailServices : IEmailService
    {
        private MailMessage mailMessage { get; set; }

        private MailAddress destinationMail { get; set; }

        private MailAddress sourceAdress { get; set; }

        private SmtpClient spClient { get; set; }

        public void EmailService()
        {
            mailMessage = new MailMessage();
          //sourceAdress = new MailAddress("danbed19905@gmail.com"); 
            destinationMail = new MailAddress("danbed19905@gmail.com");
            spClient = new SmtpClient();
            
        }

        public void SendEmail(string destinationEmail, string message)
        {
            EmailService();

            mailMessage.To.Add(new MailAddress(destinationEmail, "test"));
          //  mailMessage.From = sourceAdress;
            mailMessage.Body = message;
            spClient.Send(mailMessage);
        }

        public void SendEmail(string destinationEmail, string message, HttpPostedFileBase fileUploader)
        {
            EmailService();

            var fileName = Path.GetFileName(fileUploader.FileName);
            var attachment = new Attachment(fileUploader.InputStream, fileName);
            
            mailMessage.To.Add(new MailAddress(destinationEmail, "test"));
          //  mailMessage.From = sourceAdress;
            mailMessage.Attachments.Add(attachment);
            mailMessage.Body = message;
            spClient.Send(mailMessage);
        }

    }
}