using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using order_api.Models.Settings;
using order_api.requests.mail;

namespace order_api.Services.Mail
{
    public class MailService : IMailService
    { private readonly SmtpLogin _logins;
        public MailService(IOptions<SmtpLogin> options)
        {
            _logins = options.Value;
        }
        public async Task SendEmail(SendEmailRequest request)
        {
            try
            {
                var client = new SmtpClient();
                await client.ConnectAsync(_logins.Host, _logins.Port, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                await client.AuthenticateAsync(_logins.Username, _logins.Password);
                string body = await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "templates",
                    $"{Enum.GetName<EmailTemplateType>(request.EmailTemplateType)}.html"));
                foreach (var item in request.BodyParams)
                {
                    body = body.Replace(item.Key, item.Value);
                }
                var email = new MimeMessage
                {
                    Sender = new MailboxAddress("Plotroom Order", _logins.From),
                    Subject = request.Subject,
                    Body = new BodyBuilder
                    {
                        HtmlBody = body
                    }.ToMessageBody()
                };
                email.From.Add(InternetAddress.Parse(_logins.From));
                email.To.Add(InternetAddress.Parse(request.Email));
                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
            catch (Exception)
            {
            }
        }
    }
}
