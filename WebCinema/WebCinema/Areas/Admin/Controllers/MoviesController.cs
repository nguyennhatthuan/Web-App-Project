using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.Cinema;
using System.IO;

namespace WebCinema.Areas.Admin.Controllers
{
    public class MoviesController : BaseController
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: Admin/Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Admin/Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,Name,Length_,Director,Stars,Description_,ReleaseDate,Format_,Trailer,Poster,Thumbnail,Language_,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status_")] Movie movie, HttpPostedFileBase fileUpload)
        {

            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh bìa";
                return View(movie);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten file
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan file
                    var path = Path.Combine(Server.MapPath("~/images/Movies"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                        return View(movie);
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    movie.Poster = fileName;
                    db.Movies.Add(movie);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

        }

        // GET: Admin/Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Admin/Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MovieId,Name,Length_,Director,Stars,Description_,ReleaseDate,Format_,Trailer,Poster,Thumbnail,Language_,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,MetaKeywords,MetaDescription,Status_")] Movie movie, HttpPostedFileBase fileUpload)
        {
            
            if (ModelState.IsValid)
            {

                if (fileUpload == null)
                {
                }
                else
                {
                    //Luu ten file
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan file
                    var path = Path.Combine(Server.MapPath("~/images/Movies"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                        return View(movie);
                    }
                    else
                    {
                        fileUpload.SaveAs(path);

                    }
                    movie.Poster = fileName;
                }
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Admin/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
