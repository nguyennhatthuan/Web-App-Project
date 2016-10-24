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
            var newMovie = movieDAO.GetRandomMovies(5);
            return PartialView(newMovie);
        }

        public ActionResult _PartialNewMovieBottomSlidey()
        {
            MovieDAO movieDAO = new MovieDAO();
            var movies = movieDAO.GetRandomMovies(9);
            return PartialView(movies);
        }
        public ActionResult _PartialFeatureFilm()
        {
            MovieDAO movieDAO = new MovieDAO();
            var movies = movieDAO.GetRandomMovies(12);
            return PartialView(movies);
        }
        public ActionResult _PartialRecentlyAdded()
        {
            MovieDAO movieDAO = new MovieDAO();
            var movies = movieDAO.GetMovies(4);
            return PartialView(movies);
        }
        // Viết tạm cái Login, chưa thêm View xem thông tin User
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
            if (User != null)
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

        [HttpPost]
        public ActionResult _PartialRegister(FormCollection col)
        {
            var UserName = col["Username"];
            var Password = col["Password"];
            var Email = col["Email"];
            var Phone = col["Phone"];
            UserDAO userDAO = new UserDAO();
            int Result = userDAO.Register(UserName, Password, Email, Phone);
            if (Result == 1)
            {
                ViewBag.ThongBao = "Đăng ký thành công";
                return RedirectToAction("Index", "Cinema");
            }
            else
            {
                ViewBag.ThongBao = "Tài khoản đã có người sử dụng";
                return RedirectToAction("_PartialLogin", "Cinema");
            }
        }
        // GET: Cinema
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(FormCollection col)
        {
            UserAccount User = Session["Account"] as UserAccount;
            var email = col["email"];
            var subject = col["subject"];
            var message = col["message"];
            var Content = email + Environment.NewLine + subject + Environment.NewLine + message;
            FeedBack fb = new FeedBack();
            if (User!=null) fb.UserId = User.UserId;
            fb.CreatedDate = DateTime.Now;
            fb.Content = Content;
            UserDAO userDAO = new UserDAO();
            userDAO.AddFeedback(fb);
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            if (Session["Account"] != null || Session["Account"].ToString() != "") return Redirect("/");
            return View();
        }

        public ActionResult SignOut()
        {
            Session["Account"] = null;
            return Redirect("/");
        }
    }
}