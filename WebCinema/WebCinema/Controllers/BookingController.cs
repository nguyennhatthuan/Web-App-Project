using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.Cinema;
using HtmlAgilityPack;
using Fizzler;
using Fizzler.Systems.HtmlAgilityPack;
using System.Text;

namespace WebCinema.Controllers
{
    public class BookingController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        // GET: Booking
        public ActionResult Index(string STId)
        {
            var ShowTimeId = int.Parse(STId);
            var BookedSeat = db.Tickets.Where(s => s.ShowTimeId == ShowTimeId).ToList();
            string[] Book = new string[BookedSeat.Count];
            for (int i = 0; i < BookedSeat.Count; i++)
            {
                Book[i] = BookedSeat.ElementAt(i).SeatId.ToString();
            }
            ViewBag.BS = Book;
            return View();
        }

        [HttpPost]
        public ActionResult Index()
        {
            //HtmlWeb htmlWeb = new HtmlWeb()
            //{
            //    AutoDetectEncoding = false,
            //    OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            //};
            //HtmlDocument document = htmlWeb.Load("http://www.webtretho.com/forum/f26/");

            //var threadItems = document.DocumentNode.QuerySelectorAll("ul#threads > li").ToList();
            //List<Object> objs = new List<object>();
            //foreach (var item in threadItems)
            //{
            //    var linkNode = item.QuerySelector("a.title");
            //    var link = linkNode.Attributes["href"].Value;
            //    var text = linkNode.InnerText;
            //    var readCount = item.QuerySelector("div.folTypPost > ul > li > b").InnerText;

            //    objs.Add(new { link, text, readCount });
            //}
            return View();
        }
    }
}