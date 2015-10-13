using System;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace security
{
	[Authorize("Authenticated")]
	public class AdminController: Controller
	{
		public IActionResult Index() {
			return View();
		}
	}
}