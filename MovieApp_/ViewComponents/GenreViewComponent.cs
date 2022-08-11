
using Microsoft.AspNetCore.Mvc;
using MovieApp_.Data;
using MovieApp_.Models;
using System.Collections.Generic;

namespace MovieApp_.ViewComponents
{
    public class GenreViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];
            var genres = JenreRepository.Genres;
            return View(genres);
        }
    }
}
