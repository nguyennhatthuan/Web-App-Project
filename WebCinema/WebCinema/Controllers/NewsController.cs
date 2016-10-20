using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.Cinema;
using WebCinema.Models.DataAccess;
using WebCinema.Models;
using System.Configuration;

namespace WebCinema.Controllers
{
    public class NewsController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        public ActionResult _PartialShowNews()
        {
            var News = db.News.OrderByDescending(p => p.CreatedDate).Take(8).ToList();
            return PartialView(News);
        }

        public ActionResult _PartialTopNews()
        {
            LoadRRSvnexpress rss = new LoadRRSvnexpress(ConfigurationManager.AppSettings["urlvnexpress"]);
            ViewBag.title = rss.title;
            ViewBag.description = rss.description;
            ViewBag.link = rss.link;
            ViewBag.data = rss.items;
            return PartialView();
        }

        public ActionResult _PartialMovieNews()
        {
            LoadRRS24h rss = new LoadRRS24h(ConfigurationManager.AppSettings["url24h"]);
            ViewBag.title = rss.title;
            ViewBag.description = rss.description;
            ViewBag.language = rss.language;
            ViewBag.link = rss.link;
            ViewBag.data = rss.items;
            return PartialView();
        }

        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read(int id)
        {
            var News = db.News.SingleOrDefault(p => p.NewsId == id);
            return View(News);
        }
    }
}