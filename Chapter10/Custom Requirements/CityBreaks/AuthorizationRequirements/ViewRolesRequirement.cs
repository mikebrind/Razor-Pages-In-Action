using Microsoft.AspNetCore.Authorization;

namespace CityBreaks.AuthorizationRequirements
{
    public class ViewRolesRequirement : IAuthorizationRequirement, IAuthorizationHandler
    {
        public int Months { get; }
        public ViewRolesRequirement(int months)
        {
            Months = months > 0 ? 0 : months;
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var joiningDateClaim = context.User.FindFirst(c => c.Type == "Joining Date")?.Value;
            if (joiningDateClaim == null)
            {
                return Task.CompletedTask;
            }
            var joiningDate = Convert.ToDateTime(joiningDateClaim);

            if (context.User.HasClaim("Permission", "View Roles") &&
                  joiningDate < DateTime.Now.AddMonths(Months))
            {
                context.Succeed(this);
            }
            return Task.CompletedTask;
        }
    }
}
