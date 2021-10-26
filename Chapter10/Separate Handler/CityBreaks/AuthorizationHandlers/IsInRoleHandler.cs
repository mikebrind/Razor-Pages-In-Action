using CityBreaks.AuthorizationRequirements;
using Microsoft.AspNetCore.Authorization;

namespace CityBreaks.AuthorizationHandlers
{
    public class IsInRoleHandler : AuthorizationHandler<ViewRolesRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ViewRolesRequirement req)
        {
            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(req);
            }
            return Task.CompletedTask;
        }
    }
}
