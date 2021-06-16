using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TaskManagerPlatform.Application.Contracts.Infrastructure;
using TaskManagerPlatform.Application.Models.Mail;

namespace TaskManagerPlatform.Infrastructure.Mail.Services
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }

        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _emailSettings = mailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(_emailSettings.FromAddress, _emailSettings.Password);
            MailMessage message = new MailMessage(_emailSettings.FromAddress, email.To);
            message.IsBodyHtml = true;
            message.Subject = email.Subject;
            message.Body = email.Body;
            await client.SendMailAsync(message);
            return true;
        }
    }
}