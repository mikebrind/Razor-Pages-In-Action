using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace CityBreaks.Services
{
    public class EmailService : IEmailSender
    {
        private readonly IWebHostEnvironment _environment;
        public EmailService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage("test@test.com", email, subject, htmlMessage)
            {
                IsBodyHtml = true
            };
            using var  client = new SmtpClient()
            {
                Host = "localhost",
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = Path.Combine(_environment.ContentRootPath, "TempMail")
            };
            await client.SendMailAsync(message);
        }
    }
}
