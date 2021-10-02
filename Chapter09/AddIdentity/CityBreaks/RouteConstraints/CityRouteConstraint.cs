namespace CityBreaks.RouteContstraints
{
    public class CityRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey,
            RouteValueDictionary values, RouteDirection routeDirection)
        {
            var cities = new[] { "amsterdam", "barcelona", "berlin",
                                "copenhagen", "dubrovnik", "edinburgh",
                                "london", "madrid", "paris", "rome", "venice" };
            return cities.Contains(values[routeKey]?.ToString().ToLowerInvariant());
        }
    }
}
