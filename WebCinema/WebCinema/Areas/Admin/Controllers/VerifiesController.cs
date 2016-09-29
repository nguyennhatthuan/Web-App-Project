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
    public class VerifiesController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/Verifies
        public ActionResult Index()
        {
            var verifies = db.Verifies.Include(v => v.Staff).Include(v => v.Ticket);
            return View(verifies.ToList());
        }

        // GET: Admin/Verifies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verify verify = db.Verifies.Find(id);
            if (verify == null)
            {
                return HttpNotFound();
            }
            return View(verify);
        }

        // GET: Admin/Verifies/Create
        public ActionResult Create()
        {
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "UserName");
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SeatId");
            return View();
        }

        // POST: Admin/Verifies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,StaffId,Payment,PaymentDate")] Verify verify)
        {
            if (ModelState.IsValid)
            {
                db.Verifies.Add(verify);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "UserName", verify.StaffId);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SeatId", verify.TicketId);
            return View(verify);
        }

        // GET: Admin/Verifies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verify verify = db.Verifies.Find(id);
            if (verify == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "UserName", verify.StaffId);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SeatId", verify.TicketId);
            return View(verify);
        }

        // POST: Admin/Verifies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketId,StaffId,Payment,PaymentDate")] Verify verify)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verify).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "UserName", verify.StaffId);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "SeatId", verify.TicketId);
            return View(verify);
        }

        // GET: Admin/Verifies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verify verify = db.Verifies.Find(id);
            if (verify == null)
            {
                return HttpNotFound();
            }
            return View(verify);
        }

        // POST: Admin/Verifies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Verify verify = db.Verifies.Find(id);
            db.Verifies.Remove(verify);
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
