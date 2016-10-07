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
    public class TypeOfMoviesController : BaseController
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/TypeOfMovies
        public ActionResult Index()
        {
            return View(db.TypeOfMovies.ToList());
        }

        // GET: Admin/TypeOfMovies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfMovie typeOfMovie = db.TypeOfMovies.Find(id);
            if (typeOfMovie == null)
            {
                return HttpNotFound();
            }
            return View(typeOfMovie);
        }

        // GET: Admin/TypeOfMovies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TypeOfMovies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,Name")] TypeOfMovie typeOfMovie)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfMovies.Add(typeOfMovie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfMovie);
        }

        // GET: Admin/TypeOfMovies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfMovie typeOfMovie = db.TypeOfMovies.Find(id);
            if (typeOfMovie == null)
            {
                return HttpNotFound();
            }
            return View(typeOfMovie);
        }

        // POST: Admin/TypeOfMovies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,Name")] TypeOfMovie typeOfMovie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfMovie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfMovie);
        }

        // GET: Admin/TypeOfMovies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfMovie typeOfMovie = db.TypeOfMovies.Find(id);
            if (typeOfMovie == null)
            {
                return HttpNotFound();
            }
            return View(typeOfMovie);
        }

        // POST: Admin/TypeOfMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfMovie typeOfMovie = db.TypeOfMovies.Find(id);
            db.TypeOfMovies.Remove(typeOfMovie);
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
