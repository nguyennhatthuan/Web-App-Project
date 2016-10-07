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
    public class MovieTypesController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/MovieTypes
        public ActionResult Index()
        {
            var movieTypes = db.MovieTypes.Include(m => m.Movie).Include(m => m.TypeOfMovie);
            return View(movieTypes.ToList());
        }

        // GET: Admin/MovieTypes/Create
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name");
            ViewBag.TypeId = new SelectList(db.TypeOfMovies, "TypeId", "Name");
            return View();
        }

        // POST: Admin/MovieTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,TypeId,Date")] MovieType movieType)
        {
            if (ModelState.IsValid)
            {
                db.MovieTypes.Add(movieType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", movieType.MovieId);
            ViewBag.TypeId = new SelectList(db.TypeOfMovies, "TypeId", "Name", movieType.TypeId);
            return View(movieType);
        }

        // GET: Admin/MovieTypes/Delete/5
        public ActionResult Delete(int? id1, int? id2)
        {
            if (id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieType movieType = db.MovieTypes.Find(id1, id2);
            if (movieType == null)
            {
                return HttpNotFound();
            }
            return View(movieType);
        }

        // POST: Admin/MovieTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id1, int id2)
        {
            MovieType movieType = db.MovieTypes.Find(id1, id2);
            db.MovieTypes.Remove(movieType);
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
