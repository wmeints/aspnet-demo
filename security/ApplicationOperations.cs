using Microsoft.AspNet.Authorization;

namespace security 
{
	public static class ApplicationOperations
	{
		public static OperationAuthorizationRequirement ManageUsers = new OperationAuthorizationRequirement { Name = "ManageUsers" };
	}
}