﻿using System;
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
    public class TypeOfNewsController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/TypeOfNews
        public ActionResult Index()
        {
            return View(db.TypeOfNews.ToList());
        }

        // GET: Admin/TypeOfNews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfNew typeOfNew = db.TypeOfNews.Find(id);
            if (typeOfNew == null)
            {
                return HttpNotFound();
            }
            return View(typeOfNew);
        }

        // GET: Admin/TypeOfNews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TypeOfNews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,Name")] TypeOfNew typeOfNew)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfNews.Add(typeOfNew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfNew);
        }

        // GET: Admin/TypeOfNews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfNew typeOfNew = db.TypeOfNews.Find(id);
            if (typeOfNew == null)
            {
                return HttpNotFound();
            }
            return View(typeOfNew);
        }

        // POST: Admin/TypeOfNews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,Name")] TypeOfNew typeOfNew)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfNew).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfNew);
        }

        // GET: Admin/TypeOfNews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfNew typeOfNew = db.TypeOfNews.Find(id);
            if (typeOfNew == null)
            {
                return HttpNotFound();
            }
            return View(typeOfNew);
        }

        // POST: Admin/TypeOfNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfNew typeOfNew = db.TypeOfNews.Find(id);
            db.TypeOfNews.Remove(typeOfNew);
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
