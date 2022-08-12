using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "ID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie model)
        {
            if (ModelState.IsValid)
            {
                MovieRepository.Add(model);
                TempData["message"] = $"{model.Title} isimli film eklenmiştir";
                return RedirectToAction("List");

            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "ID", "Name");
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "ID", "Name");
            return View(MovieRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            if (ModelState.IsValid)
            {
                MovieRepository.Edit(model);
                TempData["message"] = "Film Güncellenmiştir";
                return RedirectToAction("Details", "Movies", new { @id = model.ID });
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "ID", "Name");
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            MovieRepository.Remove(id);
            TempData["message"] = "Film Silinmiştir";
            return RedirectToAction("List");
        }
    }
}
