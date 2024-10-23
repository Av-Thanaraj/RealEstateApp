using RealEstate.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Utility.Concrete.Factory
{
    public static class EmailSenderFactory
    {
        public static IEmailSender CreateEmailSender(EmailSenderType emailSenderType)
        {
            switch (emailSenderType)
            {
                case EmailSenderType.SMTP:
                    return new SmtpEmailSender();
                case EmailSenderType.OAUTH2:
                    return new OAuth2EmailSender();

                default:
                    return new SmtpEmailSender();
            }
        }
    }
}
