using Microsoft.AspNetCore.Mvc;
using MovieApp_.Data;

namespace MovieApp_.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieContext _context;
        public AdminController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult MovieList()
        {
            return View();
        }
    }
}
