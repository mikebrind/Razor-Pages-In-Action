using Microsoft.AspNetCore.Identity.UI.Services;

namespace CityBreaks.Logging
{

    public class EmailLoggerProvider : ILoggerProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public EmailLoggerProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILogger CreateLogger(string categoryName)
        {
            var emailService = _serviceProvider.GetRequiredService<IEmailSender>();
            return new EmailLogger(emailService);
        }
        public void Dispose() { }
    }
}
