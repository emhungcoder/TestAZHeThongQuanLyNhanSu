using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAZHeThongQuanLyNhanSu.Data;
using TestAZHeThongQuanLyNhanSu.Models;
using Microsoft.EntityFrameworkCore;

namespace TestAZHeThongQuanLyNhanSu.Controllers
{

    [Authorize(Roles = "Admin")]
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var positions = await _context.Positions.ToListAsync();
            return View(positions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Position model)
        {
            if (ModelState.IsValid)
            {
                _context.Positions.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null) return NotFound();

            return View(position);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Position model)
        {
            if (ModelState.IsValid)
            {
                _context.Positions.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null) return NotFound();

            return View(position);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position != null)
            {
                _context.Positions.Remove(position);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}