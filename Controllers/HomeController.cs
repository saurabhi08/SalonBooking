using Microsoft.AspNetCore.Mvc;

namespace SalonBookingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
} 