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
    public class TypeOfSeatsController : BaseController
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/TypeOfSeats
        public ActionResult Index()
        {
            return View(db.TypeOfSeats.ToList());
        }

        // GET: Admin/TypeOfSeats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfSeat typeOfSeat = db.TypeOfSeats.Find(id);
            if (typeOfSeat == null)
            {
                return HttpNotFound();
            }
            return View(typeOfSeat);
        }

        // GET: Admin/TypeOfSeats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TypeOfSeats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,Name,Price")] TypeOfSeat typeOfSeat)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfSeats.Add(typeOfSeat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfSeat);
        }

        // GET: Admin/TypeOfSeats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfSeat typeOfSeat = db.TypeOfSeats.Find(id);
            if (typeOfSeat == null)
            {
                return HttpNotFound();
            }
            return View(typeOfSeat);
        }

        // POST: Admin/TypeOfSeats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,Name,Price")] TypeOfSeat typeOfSeat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfSeat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfSeat);
        }

        // GET: Admin/TypeOfSeats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfSeat typeOfSeat = db.TypeOfSeats.Find(id);
            if (typeOfSeat == null)
            {
                return HttpNotFound();
            }
            return View(typeOfSeat);
        }

        // POST: Admin/TypeOfSeats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfSeat typeOfSeat = db.TypeOfSeats.Find(id);
            db.TypeOfSeats.Remove(typeOfSeat);
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
