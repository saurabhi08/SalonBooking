using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonBookingApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace SalonBookingApp.Controllers
{
    public class StylistController : Controller
    {
        private readonly SalonContext _context;

        // Constructor to inject the database context
        public StylistController(SalonContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Stylists.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Stylist stylist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stylist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stylist);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var stylist = await _context.Stylists.FindAsync(id);
            if (stylist == null) return NotFound();
            return View(stylist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Stylist stylist)
        {
            if (id != stylist.StylistId) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stylist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Stylists.Any(e => e.StylistId == id))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stylist);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var stylist = await _context.Stylists.FindAsync(id);
            if (stylist == null) return NotFound();
            return View(stylist);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stylist = await _context.Stylists.FindAsync(id);
            if (stylist != null)
            {
                _context.Stylists.Remove(stylist);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var stylist = await _context.Stylists.FirstOrDefaultAsync(m => m.StylistId == id);
            if (stylist == null) return NotFound();
            return View(stylist);
        }
    }
} 