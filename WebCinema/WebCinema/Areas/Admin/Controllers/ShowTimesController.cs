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
    public class ShowTimesController : BaseController
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/ShowTimes
        public ActionResult Index()
        {
            var showTimes = db.ShowTimes.Include(s => s.Movie).Include(s => s.Room);
            return View(showTimes.ToList());
        }

        // GET: Admin/ShowTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = db.ShowTimes.Find(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            return View(showTime);
        }

        // GET: Admin/ShowTimes/Create
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name");
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name");
            return View();
        }

        // POST: Admin/ShowTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowTimeId,MovieId,RoomId,StartTime,Date")] ShowTime showTime)
        {
            if (ModelState.IsValid)
            {
                db.ShowTimes.Add(showTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", showTime.MovieId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name", showTime.RoomId);
            return View(showTime);
        }

        // GET: Admin/ShowTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = db.ShowTimes.Find(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", showTime.MovieId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name", showTime.RoomId);
            return View(showTime);
        }

        // POST: Admin/ShowTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowTimeId,MovieId,RoomId,StartTime,Date")] ShowTime showTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", showTime.MovieId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name", showTime.RoomId);
            return View(showTime);
        }

        // GET: Admin/ShowTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = db.ShowTimes.Find(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            return View(showTime);
        }

        // POST: Admin/ShowTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShowTime showTime = db.ShowTimes.Find(id);
            db.ShowTimes.Remove(showTime);
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
