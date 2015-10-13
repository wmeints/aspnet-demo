using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;

namespace security 
{
    public class AdminUserHandler : AuthorizationHandler<OperationAuthorizationRequirement>
    {
        protected override void Handle(AuthorizationContext context, OperationAuthorizationRequirement requirement)
        {
			string[] allowedOperations = new[] {
				"ManageUsers"
			};
			
            if(context.User.HasClaim(ClaimTypes.Role,"Administrator") && allowedOperations.Any(operation => operation == requirement.Name))
			{
				context.Succeed(requirement);
				return;
			}
			
			context.Fail();
        }
    }
}