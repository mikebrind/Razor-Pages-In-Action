using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;


namespace CityBreaks.Services
{
public class ProductionEmailService : IEmailSender
{
    private readonly ILogger<ProductionEmailService> _logger;
    private readonly IConfiguration _config;

    public ProductionEmailService(ILogger<ProductionEmailService> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
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
        var host = _config["SmtpSettings:Host"];
        var port = Convert.ToInt32(_config["SmtpSettings:Port"]);
        var startTls = Boolean.Parse(_config["SmtpSettings:StartTls"]);
        var userName = _config["SmtpSettings:Credentials:UserName"];
        var password = _config["SmtpSettings:Credentials:Password"];
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(host, port, startTls);
        await smtp.AuthenticateAsync(userName, password);
        await smtp.SendAsync(message);
        await smtp.DisconnectAsync(true);
        _logger.LogInformation("Production email service used");
    }
}
}
