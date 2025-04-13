using Microsoft.AspNetCore.Mvc;

namespace TestAZHeThongQuanLyNhanSu.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
