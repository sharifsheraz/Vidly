using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Customers

        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek"
            }; 
            return View();
        }
        public ActionResult New()
        {
            Movie model = new Movie();
            return View("MovieForm",model);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View("MovieForm", movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View("MovieForm", movie);
            }
            else
            {
                if (movie.Id != 0)
                {
                    var movieIndb = _context.Movies.Single(m => m.Id == movie.Id);
                    movieIndb.Name = movie.Name;
                    movieIndb.NoInStock = movie.NoInStock;
                    movieIndb.Genre = movie.Genre;
                    movieIndb.ReleaseDate = movie.ReleaseDate;
                }
                else
                {
                    _context.Movies.Add(movie);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
        }

    }
}