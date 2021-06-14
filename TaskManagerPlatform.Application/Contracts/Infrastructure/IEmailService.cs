using TaskManagerPlatform.Application.Models.Mail;
using System.Threading.Tasks;

namespace TaskManagerPlatform.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}