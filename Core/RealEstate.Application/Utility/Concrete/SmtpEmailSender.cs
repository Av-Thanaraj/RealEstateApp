using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Utility.Concrete
{
    public class SmtpEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            throw new NotImplementedException();
            // Implementation for sending email using SMTP
        }
    }
}
