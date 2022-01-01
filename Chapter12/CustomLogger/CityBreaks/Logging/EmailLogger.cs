using Microsoft.AspNetCore.Identity.UI.Services;

namespace CityBreaks.Logging
{

    public class EmailLogger : ILogger
    {
        private readonly IEmailSender _emailSender;
        public EmailLogger(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel == LogLevel.Error || logLevel == LogLevel.Critical;

        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;
            var htmlMessage = state.ToString() + "<br><br>" +
                exception?.Message + "<br><br>" +
                exception?.StackTrace;
            await SendLog(htmlMessage);
        }

        private async Task SendLog(string htmlMessage)
        {
            var subject = "Error in application";
            var to = "test@example.com";
            await _emailSender.SendEmailAsync(to, subject, htmlMessage);
        }
    }
}