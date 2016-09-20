using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.Cinema;

namespace WebCinema.Controllers
{
    public class MovieController : Controller
    {
        private MovieDbContext db = new MovieDbContext();
        // GET: Movie
        public ActionResult Details(int Id)
        {
            var movie = db.Movies.SingleOrDefault(p => p.MovieId == Id);
            return View(movie);
        }
    }
}