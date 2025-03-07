using KTGK_1.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KTGK_1.Controllerss
{
    public class HangHoaController : Controller
    {
        private readonly HttpClient _httpClient;

        public HangHoaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            string apiUrl = "http://localhost:5081/api/hang_hoa";
            var response = await _httpClient.GetStringAsync(apiUrl);
            var hangHoas = JsonConvert.DeserializeObject<List<hang_hoa>>(response);
            return View(hangHoas);
        }
    }
}
