using MoviesDBMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace MoviesDBMVC.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesDBContext db = new MoviesDBContext();

        public ActionResult Index()
        {
            var movies = db.Movies.ToList();  
            return View(movies);  
        }
        [HttpPost]

        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        public ActionResult Create()
        {
            return View(); 
        }


        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                var existingMovie = db.Movies.Find(id);
                existingMovie.MovieName = movie.MovieName;
                existingMovie.DateOfRelease = movie.DateOfRelease;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }


        public ActionResult MoviesByYear(int year)
        {
            var moviesInYear = db.Movies
                .Where(m => m.DateOfRelease.Year == year)
                .ToList();

            ViewBag.Year = year; 
            return View(moviesInYear); 
        }
    }
}
