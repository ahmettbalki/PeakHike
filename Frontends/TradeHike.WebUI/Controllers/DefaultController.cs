using Microsoft.AspNetCore.Mvc;

namespace TradeHike.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
