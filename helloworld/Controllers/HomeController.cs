using Microsoft.AspNet.Mvc;

namespace helloworld
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
