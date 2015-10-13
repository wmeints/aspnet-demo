using Microsoft.AspNet.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication.Cookies;

namespace security
{
    
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("/Account/LogOn")]
        public IActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        [Route("/Account/LogOn")]
        public async Task<IActionResult> LogOn(LogOnViewModel model)
        {
            if (!Context.User.Identities.Any(identity => identity.IsAuthenticated))
            {
                var user = new ClaimsPrincipal(new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, model.UserName)
                }, CookieAuthenticationDefaults.AuthenticationScheme));
                
                await Context.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                
                return Redirect("/");
            }

            return View();
        }
        
        [Route("/Account/LogOff")]
        public async Task<IActionResult> LogOff() {
            await Context.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            return Redirect("/");
        }
    }
}
