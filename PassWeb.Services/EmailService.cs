using PassWeb.Interfaces.IServices;
using System.Net.Mail;

namespace PassWeb.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(MailMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                client.Send(mailMessage);
            }
        }
    }
}
