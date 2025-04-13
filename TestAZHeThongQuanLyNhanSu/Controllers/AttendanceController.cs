using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAZHeThongQuanLyNhanSu.Data;
using TestAZHeThongQuanLyNhanSu.Models;

namespace TestAZHeThongQuanLyNhanSu.Controllers
{
    [Authorize] // Yêu cầu đăng nhập
    public class AttendanceController : Controller
    {
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

        // Giao diện chấm công
        public IActionResult Clock()
        {
            return View();
        }

        // Chấm công vào
        [HttpPost]
        public async Task<IActionResult> ClockIn()
        {
            var username = User.Identity?.Name;
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.UserName == username);

            if (employee == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy tài khoản nhân viên.";
                return RedirectToAction("Clock");
            }

            var todayClockIn = await _context.Attendances
                .AnyAsync(a => a.EmployeeId == employee.Id && a.ClockInTime.Date == DateTime.Today);

            if (todayClockIn)
            {
                TempData["ErrorMessage"] = "Bạn đã chấm công vào hôm nay.";
                return RedirectToAction("Clock");
            }

            var attendance = new Attendance
            {
                EmployeeId = employee.Id,
                ClockInTime = DateTime.Now
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Chấm công vào thành công!";
            return RedirectToAction("Clock");
        }

        // Chấm công ra
        [HttpPost]
        public async Task<IActionResult> ClockOut()
        {
            var username = User.Identity?.Name;
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.UserName == username);

            if (employee == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy tài khoản nhân viên.";
                return RedirectToAction("Clock");
            }

            var attendance = await _context.Attendances
                .Where(a => a.EmployeeId == employee.Id && a.ClockInTime.Date == DateTime.Today && a.ClockOutTime == null)
                .OrderByDescending(a => a.ClockInTime)
                .FirstOrDefaultAsync();

            if (attendance != null)
            {
                attendance.ClockOutTime = DateTime.Now;
                _context.Attendances.Update(attendance);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Chấm công ra thành công!";
            }
            else
            {
                TempData["ErrorMessage"] = "Không tìm thấy bản ghi chấm công vào hôm nay.";
            }

            return RedirectToAction("Clock");
        }

        // Danh sách chấm công
  
        public async Task<IActionResult> Index()
        {
            var attendances = await _context.Attendances.Include(a => a.Employee).ToListAsync();
            return View(attendances);
        }
    }
}
