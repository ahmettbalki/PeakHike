using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TradeHike.Dto.CompanyDtos;

namespace TradeHike.WebUI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CompanyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Şirketler";
            ViewBag.v2 = "Şirketleri İnceleyiniz";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7151/api/Companies");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCompanyDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
