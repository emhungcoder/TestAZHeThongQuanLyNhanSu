using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAZHeThongQuanLyNhanSu.Data;
using TestAZHeThongQuanLyNhanSu.Models;
using TestAZHeThongQuanLyNhanSu.ViewModels;

namespace TestAZHeThongQuanLyNhanSu.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly AppDbContext _context;

        public EmployeeController(UserManager<Employee> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _userManager.Users.Include(e => e.Position).ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Positions = await _context.Positions.ToListAsync();
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string userName, string fullName, string password, DateTime dateOfBirth, string gender, string address, DateTime startDate, int positionId)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Positions = await _context.Positions.ToListAsync();
                return View();
            }

            var position = await _context.Positions.FindAsync(positionId);
            if (position == null)
            {
                ModelState.AddModelError("", "Chức vụ không tồn tại.");
                ViewBag.Positions = await _context.Positions.ToListAsync();
                return View();
            }

            var employee = new Employee
            {
                UserName = userName,
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                Address = address,
                StartDate = startDate,
                PositionId = positionId,
                BasicSalary = position.BasicSalary,
                Allowance = position.Allowance
            };

            var result = await _userManager.CreateAsync(employee, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(employee, "Employee");
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            ViewBag.Positions = await _context.Positions.ToListAsync();
            return View();
        }


        public async Task<IActionResult> Edit(string id)
        {
            var employee = await _userManager.Users.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return NotFound();

            var model = new EditEmployeeViewModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                Address = employee.Address,
                StartDate = employee.StartDate,
                PositionId = employee.PositionId
            };

            ViewBag.Positions = await _context.Positions.ToListAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditEmployeeViewModel model)
        {
            var employee = await _userManager.FindByIdAsync(model.Id);
            if (employee == null) return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Positions = await _context.Positions.ToListAsync();
                return View(model);
            }

            employee.FullName = model.FullName;
            employee.DateOfBirth = model.DateOfBirth;
            employee.Gender = model.Gender;
            employee.Address = model.Address;
            employee.StartDate = model.StartDate;
            employee.PositionId = model.PositionId;

            var position = await _context.Positions.FindAsync(model.PositionId);
            if (position != null)
            {
                employee.BasicSalary = position.BasicSalary;
                employee.Allowance = position.Allowance;
            }

            var updateResult = await _userManager.UpdateAsync(employee);
            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                    ModelState.AddModelError("", error.Description);

                ViewBag.Positions = await _context.Positions.ToListAsync();
                return View(model);
            }

            if (!string.IsNullOrEmpty(model.OldPassword) &&
                !string.IsNullOrEmpty(model.NewPassword) &&
                model.NewPassword == model.ConfirmPassword)
            {
                var passwordResult = await _userManager.ChangePasswordAsync(employee, model.OldPassword, model.NewPassword);
                if (!passwordResult.Succeeded)
                {
                    foreach (var error in passwordResult.Errors)
                        ModelState.AddModelError("", error.Description);

                    ViewBag.Positions = await _context.Positions.ToListAsync();
                    return View(model);
                }
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(string id)
        {
            var employee = await _userManager.Users.Include(e => e.Position).FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return NotFound();

            return View(employee);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _userManager.FindByIdAsync(id);
            if (employee != null)
            {
                await _userManager.DeleteAsync(employee);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
