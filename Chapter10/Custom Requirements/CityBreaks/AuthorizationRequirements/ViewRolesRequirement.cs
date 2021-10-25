using Microsoft.AspNetCore.Authorization;

namespace CityBreaks.AuthorizationRequirements
{
    public class ViewRolesRequirement : IAuthorizationRequirement, IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var joiningDateClaim = context.User.FindFirst(c => c.Type == "Joining Date")?.Value;
            var joiningDate = Convert.ToDateTime(joiningDateClaim);
            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(this);
            }
            if(context.User.HasClaim("Permission", "View Roles") &&
                joiningDate > DateTime.MinValue &&
                joiningDate < DateTime.Now.AddMonths(-6))
            {
                context.Succeed(this);
            }
            return Task.CompletedTask;
        }
    }
}
