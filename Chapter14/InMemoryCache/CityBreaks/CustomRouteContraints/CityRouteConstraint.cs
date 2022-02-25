using CityBreaks.Services;

namespace CityBreaks.CustomRouteContraints
{
    public class CityRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            var service = httpContext.RequestServices.GetRequiredService<ICityService>();
            var cities = Task.Run(() => service.GetCityNamesAsync());
            return cities.Result.Select(x => x.ToLowerInvariant()).Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
}
