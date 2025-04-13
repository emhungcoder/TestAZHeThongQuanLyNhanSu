using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAZHeThongQuanLyNhanSu.Data;
using TestAZHeThongQuanLyNhanSu.Models;
using TestAZHeThongQuanLyNhanSu.ViewModels;

namespace TestAZHeThongQuanLyNhanSu.Controllers
{
    public class RewardDisciplinaryController : Controller
    {
        private readonly HttpClient _httpClient;

        public RewardDisciplinaryController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> Index()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RewardDisciplinaryViewModel>>("api/rewarddisciplinary");
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RewardDisciplinaryViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/rewarddisciplinary", model);
            if (response.IsSuccessStatusCode) return RedirectToAction("Index");
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<RewardDisciplinaryViewModel>($"api/rewarddisciplinary/{id}");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RewardDisciplinaryViewModel model)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/rewarddisciplinary/{id}", model);
            if (response.IsSuccessStatusCode) return RedirectToAction("Index");
            return View(model);
        }
    }


}
