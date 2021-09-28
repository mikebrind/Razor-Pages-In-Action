using Microsoft.AspNetCore.Routing;

namespace CityBreaks.ParameterTransformers
{
    public class SlugParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            return value?.ToString().Replace(" ", "-");
        }
    }
}
