using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonBookingApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace SalonBookingApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly SalonContext _context;
        public AppointmentController(SalonContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Stylist)
                .Include(a => a.Service)
                .ToListAsync();
            return View(appointments);
        }

        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Stylists = _context.Stylists.ToList();
            ViewBag.Services = _context.Services.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Stylists = _context.Stylists.ToList();
            ViewBag.Services = _context.Services.ToList();
            return View(appointment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Stylists = _context.Stylists.ToList();
            ViewBag.Services = _context.Services.ToList();
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Appointments.Any(e => e.AppointmentId == id))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Stylists = _context.Stylists.ToList();
            ViewBag.Services = _context.Services.ToList();
            return View(appointment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var appointment = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Stylist)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var appointment = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Stylist)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }
    }
} 