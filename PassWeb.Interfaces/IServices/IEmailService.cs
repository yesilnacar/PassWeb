using System.Net.Mail;

namespace PassWeb.Interfaces.IServices
{
    public interface IEmailService
    {
        void SendEmail(MailMessage mailMessage);
    }
}
