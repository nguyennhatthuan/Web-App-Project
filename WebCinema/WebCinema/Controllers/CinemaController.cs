using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.Cinema;
using WebCinema.Models.DataAccess;

namespace WebCinema.Controllers
{
    public class CinemaController : Controller
    {

        public ActionResult _PartialGetGenre()
        {
            TypeOfMovieDAO genreDAO = new TypeOfMovieDAO();
            var genre = genreDAO.GetMovieGenre();
            return PartialView(genre);
        }
        public ActionResult _PartialSlidey()
        {
            MovieDAO movieDAO = new MovieDAO();
            var newMovie = movieDAO.GetMovies(5);
            return PartialView(newMovie);
        }

        public ActionResult _PartialNewMovieBottomSlidey()
        {
            MovieDAO movieDAO = new MovieDAO();
            var movies = movieDAO.GetMovies(9);
            return PartialView(movies);
        }

        [HttpGet]
        public ActionResult _PartialLogin()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult _PartialLogin(FormCollection col)
        {
            var UserName = col["Username"];
            var Password = col["Password"];
            UserDAO userDAO = new UserDAO();
            UserAccount user = userDAO.Login(UserName, Password);
            if (User!=null)
            {
                Session["Account"] = user;
                return RedirectToAction("Index", "Cinema");
            }
            else
            {
                //Thông báo
                return ViewBag.ThongBaoLoi = "Đăng nhập thất bại";
            }
        }
        
        // GET: Cinema
        public ActionResult Index()
        {
            return View();
        }
    }
}