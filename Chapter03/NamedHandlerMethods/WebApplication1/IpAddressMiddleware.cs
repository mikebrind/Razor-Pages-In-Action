namespace WebApplication1
{
    public class IpAddressMiddleware : IMiddleware
    {
        private ILogger<IpAddressMiddleware> _logger;
        public IpAddressMiddleware(ILogger<IpAddressMiddleware> logger)
            => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var ipAddress = context.Connection.RemoteIpAddress;
            _logger.LogInformation($"Visitor is from {ipAddress}");
            await next(context);
        }
    }
}
