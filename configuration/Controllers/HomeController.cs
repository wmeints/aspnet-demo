using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Configuration;

namespace helloworld
{
    public class HomeController : Controller
    {
        private string siteTitle;

        public HomeController(IConfiguration config) {
            siteTitle = config.GetSection("site").GetSection("title").Value;
        }

        public IActionResult Index()
        {
            ViewBag.Title = siteTitle;
            return View();
        }
    }
}
