using Microsoft.AspNetCore.Mvc;
using MovieApp_.Data;
using MovieApp_.Models;
using System.Linq;

namespace MovieApp_.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movie = new HomeViewModel()
            {
                AllMovies=_context.Movies.ToList()
            };
            return View(movie);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
