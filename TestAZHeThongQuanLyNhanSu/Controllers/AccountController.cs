using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestAZHeThongQuanLyNhanSu.Models;
using TestAZHeThongQuanLyNhanSu.ViewModels;
namespace TestAZHeThongQuanLyNhanSu.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Employee> _signInManager;

        public AccountController(SignInManager<Employee> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Đăng nhập thất bại.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}