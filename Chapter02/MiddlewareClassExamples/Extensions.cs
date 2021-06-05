using Microsoft.AspNetCore.Builder;

namespace MiddlewareClassExamples
{
    public static class Extensions
    {
        public static IApplicationBuilder UseIpAddressMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<IpAddressMiddleware>();
        }
    }
}
