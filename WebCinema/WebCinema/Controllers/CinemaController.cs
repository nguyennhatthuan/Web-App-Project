using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.Cinema;

namespace WebCinema.Controllers
{
    public class CinemaController : Controller
    {
        private MovieDbContext db = new MovieDbContext();
        private List<Movie> GetMovies(int count = 0)
        {
            if (count == 0)
                return db.Movies.ToList();
            else
                return db.Movies.OrderByDescending(m => m.CreatedDate).Take(count).ToList();
        }

        public ActionResult _PartialGetGenre()
        {
            var genre = db.TypeOfMovies.OrderByDescending(g => g.Name).ToList();
            return PartialView(genre);
        }
        public ActionResult _PartialSlidey()
        {
            var newMovie = GetMovies(5);
            return PartialView(newMovie);
        }

        public ActionResult _PartialNewMovieBottomSlidey()
        {
            var movies = GetMovies(9);
            return PartialView(movies);
        }

        
        // GET: Cinema
        public ActionResult Index()
        {
            return View();
        }
    }
}