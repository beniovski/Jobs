using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JobsPortal.Services
{
    public interface IEmailService
    {
        void SendEmail(string destinationEmail, string message);

        void SendEmail(string destinationEmail, string message, HttpPostedFileBase fileUploader);
    }
}
