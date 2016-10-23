using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.DataAccess;
using WebCinema.Models;
using PagedList;
using PagedList.Mvc;

namespace WebCinema.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Details(int Id)
        {
            MovieDAO MovieDAO = new MovieDAO();
            var movie = MovieDAO.GetOneMovie(Id);
            var Genre = MovieDAO.GetGenreofMovie(Id);
            var TheLoai = "";
            if (Genre.Count!=0)
            {
                TheLoai = Genre.First().Name;
                foreach (var item in Genre.Skip(1))
                {
                    TheLoai += ", " + item.Name;
                }
            }
            ViewBag.TheLoai = TheLoai;
            return View(movie);
        }

        public ActionResult _PartialShowTime(int Id)
        {
            MovieDAO MovieDAO = new MovieDAO();
            var showTime = MovieDAO.GetShowTimeMovie(Id);
            return PartialView(showTime);
        }

        public ActionResult Genre(int Id, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            MovieGenreDAO genre = new MovieGenreDAO();
            List<MovieGenre> Movies = genre.GetMovieByGenre(Id);
            ViewBag.GenreName = genre.GetGenreName(Id);
            return View(Movies.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult _PartialRandomMovie()
        {
            MovieDAO movieDAO = new MovieDAO();
            var newMovie = movieDAO.GetRandomMovies(6);
            return PartialView(newMovie);
        }
    }
}