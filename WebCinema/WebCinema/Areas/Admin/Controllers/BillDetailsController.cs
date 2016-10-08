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
    public class BillDetailsController : BaseController
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/BillDetails
        public ActionResult Index()
        {
            var billDetails = db.BillDetails.Include(b => b.Bill).Include(b => b.Ticket);
            return View(billDetails.ToList());
        }

        // GET: Admin/BillDetails/Details/5
        public ActionResult Details(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = db.BillDetails.Find(id1, id2);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            return View(billDetail);
        }

        // GET: Admin/BillDetails/Create
        public ActionResult Create()
        {
            ViewBag.BillId = new SelectList(db.Bills, "BillId", "BillId");
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SeatId");
            return View();
        }

        // POST: Admin/BillDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillId,TicketId,Note")] BillDetail billDetail)
        {
            if (ModelState.IsValid)
            {
                db.BillDetails.Add(billDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BillId = new SelectList(db.Bills, "BillId", "BillId", billDetail.BillId);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SeatId", billDetail.TicketId);
            return View(billDetail);
        }

        // GET: Admin/BillDetails/Edit/5
        public ActionResult Edit(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = db.BillDetails.Find(id1, id2);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillId = new SelectList(db.Bills, "BillId", "BillId", billDetail.BillId);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SeatId", billDetail.TicketId);
            return View(billDetail);
        }

        // POST: Admin/BillDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillId,TicketId,Note")] BillDetail billDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BillId = new SelectList(db.Bills, "BillId", "BillId", billDetail.BillId);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SeatId", billDetail.TicketId);
            return View(billDetail);
        }

        // GET: Admin/BillDetails/Delete/5
        public ActionResult Delete(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillDetail billDetail = db.BillDetails.Find(id1, id2);
            if (billDetail == null)
            {
                return HttpNotFound();
            }
            return View(billDetail);
        }

        // POST: Admin/BillDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id1, int id2)
        {
            BillDetail billDetail = db.BillDetails.Find(id1, id2);
            db.BillDetails.Remove(billDetail);
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
