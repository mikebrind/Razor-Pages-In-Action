using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MimeKit.IO;

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
            var pickupDirectory = Path.Combine(_environment.ContentRootPath, "TempMail");
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("test@test.com"));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = htmlMessage
            };

            await SaveToPickupDirectory(message, pickupDirectory);
            await Task.CompletedTask;
        }
        public static async Task SaveToPickupDirectory(MimeMessage message, string pickupDirectory)
        {
            do
            {
                var path = Path.Combine(pickupDirectory, Guid.NewGuid().ToString() + ".eml");
                Stream stream;

                try
                {
                    stream = File.Open(path, FileMode.CreateNew);
                }
                catch (IOException)
                {
                    if (File.Exists(path))
                        continue;
                    throw;
                }

                try
                {
                    using (stream)
                    {
                        using var filtered = new FilteredStream(stream);
                        filtered.Add(new SmtpDataFilter());

                        var options = FormatOptions.Default.Clone();
                        options.NewLineFormat = NewLineFormat.Dos;

                        await message.WriteToAsync(options, filtered);
                        await filtered.FlushAsync();
                        return;
                    }
                }
                catch
                {
                    File.Delete(path);
                    throw;
                }
            } while (true);
        }
    }
}