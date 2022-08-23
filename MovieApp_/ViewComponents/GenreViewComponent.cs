
using Microsoft.AspNetCore.Mvc;
using MovieApp_.Data;
using MovieApp_.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp_.ViewComponents
{
    public class GenreViewComponent : ViewComponent
    {
        private readonly MovieContext _context;

        public GenreViewComponent(MovieContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];
            var genres = _context.Genres.ToList();
            return View(genres);
        }
    }
}
