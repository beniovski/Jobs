using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsPortal.Services
{
    public interface IEmailService
    {
        void SendEmail(string destinationEmail, string message);
    }
}
