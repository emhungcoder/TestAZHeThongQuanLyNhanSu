using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAZHeThongQuanLyNhanSu.Data;
using TestAZHeThongQuanLyNhanSu.Models;

namespace TestAZHeThongQuanLyNhanSu.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly AppDbContext _context;

        public TimeSlotController(AppDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách ca làm việc
        public async Task<IActionResult> Index()
        {
            var timeSlots = await _context.TimeSlots.ToListAsync();
            return View(timeSlots);
        }

        // Hiển thị form tạo ca làm mới
        public IActionResult Create()
        {
            ViewData["Title"] = "Tạo Ca Làm Mới";
            return View();
        }

        // Xử lý việc tạo ca làm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TimeSlot timeSlot)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(timeSlot);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi trong trường hợp có vấn đề khi thêm mới
                    ModelState.AddModelError("", $"Có lỗi khi tạo ca làm mới: {ex.Message}");
                }
            }
            return View(timeSlot);
        }

        // Hiển thị form xác nhận xóa ca làm
        public async Task<IActionResult> Delete(int id)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(id);
            if (timeSlot == null)
            {
                return NotFound();
            }
            return View(timeSlot);
        }

        // Xử lý việc xóa ca làm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(id);
            if (timeSlot != null)
            {
                try
                {
                    _context.TimeSlots.Remove(timeSlot);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi trong trường hợp có vấn đề khi xóa
                    ModelState.AddModelError("", $"Có lỗi khi xóa ca làm: {ex.Message}");
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
