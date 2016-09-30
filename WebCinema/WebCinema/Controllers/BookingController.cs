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
using System.Web.Script.Serialization;

namespace WebCinema.Controllers
{
    public class BookingController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        // GET: Booking
        public ActionResult Index(string STId)
        {
            var ShowTimeId = int.Parse(STId);
            var Show = db.ShowTimes.SingleOrDefault(s => s.ShowTimeId == ShowTimeId);
            var MovieName = db.Movies.SingleOrDefault(s => s.ShowTimes.Any(p => p.ShowTimeId == ShowTimeId)).Name;
            var Room = db.Rooms.SingleOrDefault(r => r.ShowTimes.Any(p => p.ShowTimeId == ShowTimeId)).Name;
            var BookedSeat = db.Tickets.Where(s => s.ShowTimeId == ShowTimeId).ToList();
            ViewBag.MovieName = MovieName;
            ViewBag.Room = Room;
            var Time = Show.StartTime.Value.Hours.ToString() + ":" + Show.StartTime.Value.Minutes.ToString() + ", " + Show.Date.Value.Date.ToString("dd/MM/yyyy");
            ViewBag.Time = Time;
            if (BookedSeat.Count > 0)
            {
                string[] Book = new string[BookedSeat.Count];
                for (int i = 0; i < BookedSeat.Count; i++)
                {
                    Book[i] = BookedSeat.ElementAt(i).SeatId.ToString();
                }
                ViewBag.Book = Book;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }
    }
}