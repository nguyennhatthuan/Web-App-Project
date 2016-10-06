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
            var MovieId = db.Movies.SingleOrDefault(s => s.ShowTimes.Any(p => p.ShowTimeId == ShowTimeId)).MovieId;
            var Room = db.Rooms.SingleOrDefault(r => r.ShowTimes.Any(p => p.ShowTimeId == ShowTimeId)).Name;
            var BookedSeat = db.Tickets.Where(s => s.ShowTimeId == ShowTimeId).ToList();
            var TicketPrice = db.TypeOfSeats.SingleOrDefault(t => t.TypeId == 2).Price;
            ViewBag.TicketPrice = TicketPrice;
            ViewBag.MovieName = MovieName;
            ViewBag.MovieId = MovieId;
            ViewBag.Room = Room;
            ViewBag.ShowTimeId = STId;
            var Time = Show.StartTime.Value.Hours.ToString() + ":" + Show.StartTime.Value.Minutes.ToString() + ", " + Show.Date.Value.Date.ToString("dd/MM/yyyy");
            ViewBag.Time = Time;
            var Count = BookedSeat.Count;
            if (Count > 0)
            {
                string[] Book = new string[Count];
                for (int i = 0; i < Count; i++)
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
            //Send to Thuấn in the future, To do:
            //khi chọn các ghế bên Javascript, lưu các ghế đã chọn vào 1 mảng, chứa trong đó
            //sau đó dùng Json chuyển về lại cho C# nhận ra các ghế đã chọn.

            return View();
        }

        [HttpPost]
        public ActionResult BookingTicket(FormCollection col)
        {
            var BookedSeats = col["GheDaChon"].ToString();
            var MovieId = col["MaPhim"];
            var ShowTimeId = col["MaSuat"];
            var Price = col["Tien"];
            return View();
        }
    }
}