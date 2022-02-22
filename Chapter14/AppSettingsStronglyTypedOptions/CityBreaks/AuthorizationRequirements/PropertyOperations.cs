using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace CityBreaks.AuthorizationRequirements
{
    public static class PropertyOperations
    {
        public static OperationAuthorizationRequirement Create =
            new () { Name = nameof(Create) };
        public static OperationAuthorizationRequirement Read =
            new () { Name = nameof(Read) };
        public static OperationAuthorizationRequirement Edit =
            new () { Name = nameof(Edit) };
        public static OperationAuthorizationRequirement Delete =
            new () { Name = nameof(Delete) };
    }
}
