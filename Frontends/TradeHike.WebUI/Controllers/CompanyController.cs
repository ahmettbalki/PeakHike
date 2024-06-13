using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TradeHike.Dto.CompanyDtos;
using System.Linq.Expressions; // LinQ ifadesi için gerekli

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

                var orderedValues = values.AsQueryable().OrderBy(x => x.Name).ToList();

                return View(orderedValues);
            }
            return View();
        }

        public async Task<IActionResult> CompanyDetail(int id)
        {
            ViewBag.v1 = "Şirketler";
            ViewBag.v2 = "Şirketlerin Detaylı Bilgileri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7151/api/Companies/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var company = JsonConvert.DeserializeObject<ResultCompanyDto>(jsonData);
                return View(company);
            }
            return NotFound();
        }
    }
}