using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TradeHike.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminLayout")]
    [Authorize(Roles = "Admin")]

    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["AdminName"] = User.Identity.Name;
            return View();
        }
        public PartialViewResult AdminHeaderPartial()
        {
            ViewData["AdminName"] = User.Identity.Name;
            return PartialView();
        }
        public PartialViewResult AdminNavbarPartial()
        {
            ViewData["AdminName"] = User.Identity.Name;
            return PartialView();
        }
        public PartialViewResult AdminSidebarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminScriptPartial()
        {
            return PartialView();
        }
    }
}
