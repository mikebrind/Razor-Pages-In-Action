using Microsoft.AspNetCore.Identity.UI.Services;

namespace CityBreaks.Logging;

public class EmailLogger : ILogger
{
    private readonly IEmailSender _emailService;
    public EmailLogger(IEmailSender emailService )
    {
        _emailService = emailService;
    }
    public IDisposable BeginScope<TState>(TState state) => null;

    public bool IsEnabled(LogLevel logLevel) => logLevel == LogLevel.Error || logLevel == LogLevel.Critical;

    public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (!IsEnabled(logLevel))
            return;
        var htmlMessage = exception != null ?
            exception.Message + "<br><br>" + exception.StackTrace : 
            state.ToString();
        await SendLog(htmlMessage);
    }

    private async Task SendLog(string htmlMessage)
    {
        var subject = "Error in application";
        var to = "test@example.com";
        await _emailService.SendEmailAsync(to, subject, htmlMessage);
    }
}
