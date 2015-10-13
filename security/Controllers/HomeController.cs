using System.Security.Claims;
using Microsoft.AspNet.Mvc;

namespace security
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
