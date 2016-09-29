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
    public class AdvertisingsController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/Advertisings
        public ActionResult Index()
        {
            var advertisings = db.Advertisings.Include(a => a.Movie);
            return View(advertisings.ToList());
        }

        // GET: Admin/Advertisings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertising advertising = db.Advertisings.Find(id);
            if (advertising == null)
            {
                return HttpNotFound();
            }
            return View(advertising);
        }

        // GET: Admin/Advertisings/Create
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name");
            return View();
        }

        // POST: Admin/Advertisings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdverId,MovieId,Active")] Advertising advertising)
        {
            if (ModelState.IsValid)
            {
                db.Advertisings.Add(advertising);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", advertising.MovieId);
            return View(advertising);
        }

        // GET: Admin/Advertisings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertising advertising = db.Advertisings.Find(id);
            if (advertising == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", advertising.MovieId);
            return View(advertising);
        }

        // POST: Admin/Advertisings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdverId,MovieId,Active")] Advertising advertising)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertising).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", advertising.MovieId);
            return View(advertising);
        }

        // GET: Admin/Advertisings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertising advertising = db.Advertisings.Find(id);
            if (advertising == null)
            {
                return HttpNotFound();
            }
            return View(advertising);
        }

        // POST: Admin/Advertisings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertising advertising = db.Advertisings.Find(id);
            db.Advertisings.Remove(advertising);
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
