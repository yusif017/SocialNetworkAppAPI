using SocialNetwork.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Utilities.EmailHelper
{
    public class MailHelper : IMailHelper
    {
        public bool SendEmail(string mailAddress, string token, bool bodyHtml)
        {
            var emailAddress = EmailConfiguration.Email;
            var emailPassword = EmailConfiguration.Password;

            string senderEmail = emailAddress;
            string senderPassword = emailPassword;

            // Smtp, Mailkit
            //Create the SMTP client
            SmtpClient smtpClient = new(EmailConfiguration.Smtp, EmailConfiguration.Port);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            try
            {
                // Create the email message
                MailMessage mailMessage = new();
                mailMessage.From = new MailAddress(senderEmail);
                mailMessage.To.Add(mailAddress);
                mailMessage.Subject = $"Message from - {EmailConfiguration.Email}";
                mailMessage.Body = $"<a href=''>Tesdiq et</a>";
                // Specify that the body contains HTML
                mailMessage.IsBodyHtml = true;
                // Send the email
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
