using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.Cinema;

namespace WebCinema.Areas.Admin.Controllers
{
    public class TicketsController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Seat).Include(t => t.ShowTime);
            return View(tickets.ToList());
        }

        // GET: Admin/Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Admin/Tickets/Create
        public ActionResult Create()
        {
            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatId");
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "ShowTimeId", "ShowTimeId");
            return View();
        }

        // POST: Admin/Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,SeatId,ShowTimeId,BookingDate,Status_")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatId", ticket.SeatId);
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "ShowTimeId", "ShowTimeId", ticket.ShowTimeId);
            return View(ticket);
        }

        // GET: Admin/Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatId", ticket.SeatId);
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "ShowTimeId", "ShowTimeId", ticket.ShowTimeId);
            return View(ticket);
        }

        // POST: Admin/Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketId,SeatId,ShowTimeId,BookingDate,Status_")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SeatId = new SelectList(db.Seats, "SeatId", "SeatId", ticket.SeatId);
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "ShowTimeId", "ShowTimeId", ticket.ShowTimeId);
            return View(ticket);
        }

        // GET: Admin/Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Admin/Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
