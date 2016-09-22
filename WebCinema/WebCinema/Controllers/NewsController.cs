using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.Cinema;
using WebCinema.Models.DataAccess;

namespace WebCinema.Controllers
{
    public class NewsController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        public ActionResult ShowNews(int count)
        {
            var news = from n in db.News select n;
            return PartialView(news);
        }
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read()
        {
            return View();
        }
    }
}