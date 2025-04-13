using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAZHeThongQuanLyNhanSu.Data;
using TestAZHeThongQuanLyNhanSu.Models;

namespace TestAZHeThongQuanLyNhanSu.Controllers
{
    public class WorkingHoursController : Controller
    {
        private readonly AppDbContext _context;

        public WorkingHoursController(AppDbContext context)
        {
            _context = context;
        }

        // Hiển thị form tạo mới ca làm việc
        public async Task<IActionResult> Create()
        {
            ViewData["EmployeeId"] = new SelectList(await _context.Employees.ToListAsync(), "Id", "FullName");
            ViewData["TimeSlotId"] = new SelectList(await _context.TimeSlots.ToListAsync(), "Id", "Name");
            return View();
        }

        // Xử lý tạo mới ca làm việc
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkingHours workingHours)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(workingHours);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Có lỗi khi tạo ca làm việc: {ex.Message}");
                }
            }

            // Đảm bảo dữ liệu chọn được cho dropdown khi form không hợp lệ
            ViewData["EmployeeId"] = new SelectList(await _context.Employees.ToListAsync(), "Id", "FullName", workingHours.EmployeeId);
            ViewData["TimeSlotId"] = new SelectList(await _context.TimeSlots.ToListAsync(), "Id", "Name", workingHours.TimeSlotId);
            return View(workingHours);
        }

        // Hiển thị form chỉnh sửa ca làm việc
        public async Task<IActionResult> Edit(int id)
        {
            var workingHours = await _context.WorkingHours.FindAsync(id);
            if (workingHours == null)
            {
                return NotFound();
            }

            ViewData["EmployeeId"] = new SelectList(await _context.Employees.ToListAsync(), "Id", "FullName", workingHours.EmployeeId);
            ViewData["TimeSlotId"] = new SelectList(await _context.TimeSlots.ToListAsync(), "Id", "Name", workingHours.TimeSlotId);
            return View(workingHours);
        }

        // Xử lý chỉnh sửa ca làm việc
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkingHours workingHours)
        {
            if (id != workingHours.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingHours);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.WorkingHours.Any(w => w.Id == workingHours.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // Đảm bảo dữ liệu chọn được cho dropdown khi form không hợp lệ
            ViewData["EmployeeId"] = new SelectList(await _context.Employees.ToListAsync(), "Id", "FullName", workingHours.EmployeeId);
            ViewData["TimeSlotId"] = new SelectList(await _context.TimeSlots.ToListAsync(), "Id", "Name", workingHours.TimeSlotId);
            return View(workingHours);
        }

        // Hiển thị danh sách các ca làm việc
        public async Task<IActionResult> Index()
        {
            var workingHours = await _context.WorkingHours
                .Include(w => w.Employee)  // Bao gồm thông tin nhân viên
                .Include(w => w.TimeSlot)  // Bao gồm thông tin ca làm việc
                .ToListAsync();
            return View(workingHours);
        }
    }

}
