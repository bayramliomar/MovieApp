using Microsoft.AspNetCore.Mvc;
using MovieApp_.Data;
using MovieApp_.Models;
using System;
using System.Collections.Generic;

namespace MovieApp_.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult List(int? id)
        {
            var query = HttpContext.Request.Query["query"];
            var movie = MovieRepository.Movies;
            if (!String.IsNullOrEmpty(query))
            {
                movie = MovieRepository.Search(query);
            }

            if (id != null)
            {
                movie = MovieRepository.GetByGenreId((int)id);
            }

            var model = new MovieViewModel()
            {
                Movies = movie
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = MovieRepository.GetById(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie model)
        {
            MovieRepository.Add(model);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(MovieRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            MovieRepository.Edit(model);
            return RedirectToAction("Details", "Movies", new { @id=model.ID});
        }
    }
}
