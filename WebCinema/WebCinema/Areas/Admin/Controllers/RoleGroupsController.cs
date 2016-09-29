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
    public class RoleGroupsController : Controller
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/RoleGroups
        public ActionResult Index()
        {
            return View(db.RoleGroups.ToList());
        }

        // GET: Admin/RoleGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleGroup roleGroup = db.RoleGroups.Find(id);
            if (roleGroup == null)
            {
                return HttpNotFound();
            }
            return View(roleGroup);
        }

        // GET: Admin/RoleGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RoleGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RGId,Name,Add_,Edit_,Delete_")] RoleGroup roleGroup)
        {
            if (ModelState.IsValid)
            {
                db.RoleGroups.Add(roleGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleGroup);
        }

        // GET: Admin/RoleGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleGroup roleGroup = db.RoleGroups.Find(id);
            if (roleGroup == null)
            {
                return HttpNotFound();
            }
            return View(roleGroup);
        }

        // POST: Admin/RoleGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RGId,Name,Add_,Edit_,Delete_")] RoleGroup roleGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleGroup);
        }

        // GET: Admin/RoleGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleGroup roleGroup = db.RoleGroups.Find(id);
            if (roleGroup == null)
            {
                return HttpNotFound();
            }
            return View(roleGroup);
        }

        // POST: Admin/RoleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleGroup roleGroup = db.RoleGroups.Find(id);
            db.RoleGroups.Remove(roleGroup);
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
