using Microsoft.AspNetCore.Identity.UI.Services;

namespace CityBreaks.Services
{
    public class ProductionEmailService : IEmailSender
    {
        private readonly ILogger<ProductionEmailService> _logger;   
        public ProductionEmailService(ILogger<ProductionEmailService> logger)
        {
            _logger = logger;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogInformation("Production email service used");
            return Task.CompletedTask;
        }
    }
}
