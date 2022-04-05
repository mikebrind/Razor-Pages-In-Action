using CityBreaks.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;


namespace CityBreaks.Services
{
    public class ProductionEmailService : IEmailSender
    {
        private readonly ILogger<ProductionEmailService> _logger;
        private readonly SmtpSettings _settings;

        public ProductionEmailService(ILogger<ProductionEmailService> logger, SmtpSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("test@test.com"));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = htmlMessage
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_settings.Host,_settings.Port, _settings.StartTls);
            if (!string.IsNullOrEmpty(_settings.Credentials.UserName))
            {
                await smtp.AuthenticateAsync(_settings.Credentials.UserName, _settings.Credentials.Password);
            }
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
            _logger.LogInformation("Production email service used");
        }
    }
}