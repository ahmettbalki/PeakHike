using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TradeHike.Persistence.Context;
using TradeHike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TradeHike.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/UserDashboard")]
    [Authorize(Roles = "Member")]

    public class UserDashboardController : Controller
    {
        private readonly MyContext _context;

        public UserDashboardController(MyContext context)
        {
            _context = context;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.AppUsers.FirstOrDefault(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Route("UpdateDashboard/{id}")]
        [HttpGet]
        public IActionResult UpdateDashboard(int id)
        {
            var user = _context.AppUsers.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Route("UpdateDashboard/{id}")]
        [HttpPost]
        public IActionResult UpdateDashboard(AppUser updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedUser);
            }

            var user = _context.AppUsers.Find(updatedUser.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.Username = updatedUser.Username;
            user.Name = updatedUser.Name;
            user.Surname = updatedUser.Surname;
            user.Email = updatedUser.Email;

            _context.Update(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
