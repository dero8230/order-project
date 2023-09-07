using order_api.requests.mail;

namespace order_api.Services.Mail
{
    public interface IMailService : IServerService
    {
        Task SendEmail(SendEmailRequest request);
    }
}
