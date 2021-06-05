using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MiddlewareClassExamples
{
    public class IpAddressMiddleware
    {
        private readonly RequestDelegate _next;
        public IpAddressMiddleware(RequestDelegate next) => _next = next; 

        public async Task InvokeAsync(HttpContext context, ILogger<IpAddressMiddleware> logger) 
        {
            var ipAddress = context.Connection.RemoteIpAddress;
            logger.LogInformation($"Visitor is from {ipAddress}"); 
            await _next(context); 
        }
    }
}
