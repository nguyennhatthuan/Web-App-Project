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
            if (Session["Account"] == null || Session["Account"].ToString() == "")
            {
                return RedirectToAction("_PartialLogin", "Cinema");
                // gọi sự kiện OnClick bên Javasctipt
            }
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
        public ActionResult BookingTicket(FormCollection col)
        {
            var BookedSeats = col["GheDaChon"].ToString();
            var MovieId = col["MaPhim"];
            var ShowTimeId = col["MaSuat"];
            var Price = col["Tien"];
            UserAccount User = (UserAccount)Session["Account"];

            Bill bill = new Bill();
            bill.Date_ = DateTime.Now;
            bill.Price = decimal.Parse(Price);
            bill.UserId = User.UserId;
            db.Bills.Add(bill);
            db.SaveChanges();

            string[] Seats = BookedSeats.Split(',');
            foreach (var item in Seats)
            {
                Ticket ticket = new Ticket();
                ticket.SeatId = item;
                ticket.ShowTimeId = int.Parse(ShowTimeId);
                ticket.BookingDate = DateTime.Now;
                ticket.Status_ = false;
                db.Tickets.Add(ticket);
            }
            db.SaveChanges();

            decimal GiaTien = decimal.Parse(Price);
            var billId = db.Bills.Where(b => b.Price == GiaTien && b.UserId == User.UserId && b.Date_.Value.Year == DateTime.Now.Year && b.Date_.Value.Month == DateTime.Now.Month && b.Date_.Value.Day == DateTime.Now.Day).OrderByDescending(b=>b.BillId).Single().BillId;
            var ticketBookedId = "";
            foreach (var item in Seats)
            {
                var ticketId = db.Tickets.FirstOrDefault(t => t.SeatId == item).TicketId;
                ticketBookedId += ", " + ticketId;
            }

            string[] TicketBooked = ticketBookedId.Split(',');

            foreach (var item in TicketBooked.Skip(1))
            {
                BillDetail billDetails = new BillDetail();
                billDetails.BillId = billId;
                billDetails.TicketId = int.Parse(item);
                db.BillDetails.Add(billDetails);
            }
            db.SaveChanges();
            return RedirectToAction("Success", new { BillId = billId });
        }

        public ActionResult Success(int BillId)
        {
            string Notification = "Cám ơn bạn đã mua vé, mã Hóa Đơn của bạn là " + BillId + ". Chúng tôi sẽ liên hệ bạn nhanh nhất có thể.";
            ViewBag.Notification = Notification;
            return View();
        }
    }
}