using Microsoft.AspNetCore.Mvc;

namespace TradeHike.WebUI.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
