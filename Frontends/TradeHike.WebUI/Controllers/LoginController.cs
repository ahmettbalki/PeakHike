using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TradeHike.Domain.Entities;
using TradeHike.Persistence.Context;

namespace TradeHike.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyContext _context;

		public LoginController(MyContext context)
		{
			_context = context;
		}

		[AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Index(Admin p)
        {
            var datavalue = _context.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin"),
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
			}
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
