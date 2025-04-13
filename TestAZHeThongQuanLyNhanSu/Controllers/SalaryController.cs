using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAZHeThongQuanLyNhanSu.Data;
using TestAZHeThongQuanLyNhanSu.Enums;
using TestAZHeThongQuanLyNhanSu.Models;
using TestAZHeThongQuanLyNhanSu.ViewModels;

namespace TestAZHeThongQuanLyNhanSu.Controllers
{
    public class SalaryController : Controller
    {
        private readonly HttpClient _httpClient;

        public SalaryController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> Index()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SalaryViewModel>>("api/salary");
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalaryViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/salary", model);
            if (response.IsSuccessStatusCode) return RedirectToAction("Index");
            return View(model);
        }
    }

}
