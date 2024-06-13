using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUser p)
        {
            var datavalue = _context.AppUsers.Include(u => u.AppRole)
                                              .FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);

            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, datavalue.Username),
                    new Claim(ClaimTypes.Role, datavalue.AppRole.AppRoleName),
                    new Claim(ClaimTypes.NameIdentifier, datavalue.Id.ToString())
                };
                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                if (datavalue.AppRole.AppRoleName == "Admin")
                {
                    return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });
                }
                else if (datavalue.AppRole.AppRoleName == "Member")
                {
                    return RedirectToAction("Index", "UserDashboard", new { area = "User" });
                }
            }
            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Default");
        }
    }
}
