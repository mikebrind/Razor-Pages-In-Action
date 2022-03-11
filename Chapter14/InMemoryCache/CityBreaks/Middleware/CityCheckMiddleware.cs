using CityBreaks.Services;

namespace CityBreaks.Middleware
{
    public class CityCheckMiddleware : IMiddleware
    {
        private readonly ICityService _cityService;

        public CityCheckMiddleware(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)    
        {
            if(context.Request.Path.StartsWithSegments(new PathString("/city")))
            {
                var city = context.GetRouteData().Values["name"];
                if (city != null)
                {
                    var cities = await _cityService.GetCityNamesAsync();
                    if(cities.Select(c => c.ToLowerInvariant()).Contains(city.ToString().ToLowerInvariant()))
                    {
                        await next(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 404;
                    }
                }
            }
            else 
            { 
                await next(context);
            }
        }
    }
}
