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
        public ActionResult _PartialShowNews()
        {
            var News = db.News.OrderByDescending(p => p.CreatedDate).Take(8).ToList();
            return PartialView(News);
        }

        public ActionResult _PartialTopNews()
        {
            var News = db.News.OrderByDescending(p => p.CreatedDate).Take(6).ToList();
            return PartialView(News);
        }

        // 2 Action trên là 2 Partial tách ra để gắn vào trang Index, ShowNews dùng để hiện các tin tức của Lastest News
        // TopNews là Partial để hiện cái khung bên phải
        // Ngoài ra còn thẻ Movie News nữa, chưa chỉnh, cái đó từ từ :))
        // Chú làm cái Read là OK :v


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