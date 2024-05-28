using Microsoft.AspNetCore.Mvc;

namespace TradeHike.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
