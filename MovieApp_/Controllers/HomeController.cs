using Microsoft.AspNetCore.Mvc;
using MovieApp_.Data;
using MovieApp_.Models;

namespace MovieApp_.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var movie = new HomeViewModel()
            {
                AllMovies=MovieRepository.Movies
            };
            return View(movie);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
