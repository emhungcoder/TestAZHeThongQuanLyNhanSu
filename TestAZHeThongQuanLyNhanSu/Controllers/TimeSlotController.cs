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

        public async Task<IActionResult> Index()
        {
            var timeSlots = await _context.TimeSlots.ToListAsync();
            return View(timeSlots);
        }

     
        public IActionResult Create()
        {
            ViewData["Title"] = "Tạo Ca Làm Mới";
            return View();
        }

       
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
                   
                    ModelState.AddModelError("", $"Có lỗi khi tạo ca làm mới: {ex.Message}");
                }
            }
            return View(timeSlot);
        }

     
        public async Task<IActionResult> Delete(int id)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(id);
            if (timeSlot == null)
            {
                return NotFound();
            }
            return View(timeSlot);
        }

        
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
                  
                    ModelState.AddModelError("", $"Có lỗi khi xóa ca làm: {ex.Message}");
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
