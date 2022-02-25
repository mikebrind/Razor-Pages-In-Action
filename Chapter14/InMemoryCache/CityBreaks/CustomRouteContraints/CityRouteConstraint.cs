using CityBreaks.Services;

namespace CityBreaks.CustomRouteContraints
{
    public class CityRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            var service = httpContext.RequestServices.GetRequiredService<ICityService>();
            var task = Task.Run(() => service.GetCityNamesAsync());
            var cities = task.Result.Select(x => x.ToLowerInvariant());
            return cities.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
}
