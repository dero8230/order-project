using Microsoft.Extensions.Options;
using order_api.Models.Settings;
using order_api.requests.mail;
using System.Net;
using System.Net.Mail;

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
                using var client = new SmtpClient(_logins.Host, _logins.Port);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_logins.Username, _logins.Password);
                client.EnableSsl = _logins.UseSsl;

                string body = await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "templates",
                    $"{Enum.GetName(request.EmailTemplateType)}.html"));

                foreach (var item in request.BodyParams)
                {
                    body = body.Replace(item.Key, item.Value);
                }

                using var mail = new MailMessage();
                mail.From = new MailAddress(_logins.From, "Plotroom Order");
                mail.Subject = request.Subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.To.Add(request.Email);

                await client.SendMailAsync(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
