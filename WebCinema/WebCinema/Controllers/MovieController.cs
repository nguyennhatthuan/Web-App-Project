using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.DataAccess;
using WebCinema.Models;

namespace WebCinema.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Details(int Id)
        {
            MovieDAO MovieDAO = new MovieDAO();
            var movie = MovieDAO.GetOneMovie(Id);
            return View(movie);
        }

        public ActionResult Genre(int Id)
        {
            MovieGenreDAO genre = new MovieGenreDAO();
            List<MovieGenre> Movies = genre.GetMovieByGenre(Id);
            return View(Movies);
        }
    }
}