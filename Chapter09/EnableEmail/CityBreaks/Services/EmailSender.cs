using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace CityBreaks.Services
{
    public class EmailSender : IEmailSender
    {
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
                PickupDirectoryLocation = @"C:\Maildump"
            };
            await client.SendMailAsync(message);
        }
    }
}
