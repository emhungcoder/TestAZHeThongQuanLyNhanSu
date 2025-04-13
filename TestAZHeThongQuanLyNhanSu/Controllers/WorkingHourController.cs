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

      
        public async Task<IActionResult> Create()
        {
            ViewData["EmployeeId"] = new SelectList(await _context.Employees.ToListAsync(), "Id", "FullName");
            ViewData["TimeSlotId"] = new SelectList(await _context.TimeSlots.ToListAsync(), "Id", "Name");
            return View();
        }

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

      
            ViewData["EmployeeId"] = new SelectList(await _context.Employees.ToListAsync(), "Id", "FullName", workingHours.EmployeeId);
            ViewData["TimeSlotId"] = new SelectList(await _context.TimeSlots.ToListAsync(), "Id", "Name", workingHours.TimeSlotId);
            return View(workingHours);
        }

     
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

          
            ViewData["EmployeeId"] = new SelectList(await _context.Employees.ToListAsync(), "Id", "FullName", workingHours.EmployeeId);
            ViewData["TimeSlotId"] = new SelectList(await _context.TimeSlots.ToListAsync(), "Id", "Name", workingHours.TimeSlotId);
            return View(workingHours);
        }

       
        public async Task<IActionResult> Index()
        {
            var workingHours = await _context.WorkingHours
                .Include(w => w.Employee)  
                .Include(w => w.TimeSlot)  
                .ToListAsync();
            return View(workingHours);
        }
    }

}
