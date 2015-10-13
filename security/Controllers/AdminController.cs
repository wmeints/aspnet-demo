using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace security
{
	[Authorize("Authenticated")]
	public class AdminController: Controller
	{
		private IAuthorizationService _authorizationService;
		
		public AdminController(IAuthorizationService authorizationService)
		{
			_authorizationService = authorizationService;
		}
		
		public IActionResult Index() {
			return View();
		}
		
		// OPTIONAL: Use authorize operations to build resource-based authorization.
		// With this you can authorize specific operations quite easily.
		
		//  public async Task<IActionResult> Index() {
		//  	if(await _authorizationService.AuthorizeAsync(Context.User, null, ApplicationOperations.ManageUsers))
		//  	{
		//  		return View();				
		//  	}
			
		//  	return new ChallengeResult();
		//  }
	}
}