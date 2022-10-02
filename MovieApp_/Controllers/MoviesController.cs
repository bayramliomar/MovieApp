using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp_.Data;
using MovieApp_.Models;
using MovieApp_.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieApp_.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List(int? id)
        {
            //string idd = HttpContext.Request.RouteValues["id"].ToString();
            string query = HttpContext.Request.Query["query"];
            //var movie = MovieRepository.Movies;
            var movie = _context.Movies.AsQueryable();
            if (!String.IsNullOrEmpty(query))
            {
                //movie = MovieRepository.Search(query);
                movie = movie.Where(x => x.Title.ToLower().Contains(query.ToLower()) || x.Description.ToLower().Contains(query.ToLower()));
            }

            if (id != null)
            {
                //movie = MovieRepository.GetByGenreId((int)id);
                movie = movie.Include(x=>x.Genres).Where(x => x.Genres.Any(x=>x.ID == id));
            }

            var model = new MovieViewModel()
            {
                Movies = movie.ToList()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //var model = MovieRepository.GetById(id);
            var model = _context.Movies.Find(id);
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
                //MovieRepository.Add(model);
                _context.Add(model);
                _context.SaveChanges();
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
            return View(_context.Movies.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie model)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.Edit(model);
                _context.Movies.Update(model);
                _context.SaveChanges();
                TempData["message"] = "Film Güncellenmiştir";
                return RedirectToAction("Details", "Movies", new { @id = model.ID });
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "ID", "Name");
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //MovieRepository.Remove(id);
            var movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            TempData["message"] = "Film Silinmiştir";
            return RedirectToAction("List");
        }
    }
}
