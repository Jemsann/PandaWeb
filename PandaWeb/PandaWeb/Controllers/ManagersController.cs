using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PandaWeb.Models;

namespace PandaWeb.Controllers
{
    public class ManagersController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Managers
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: Managers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Courses.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Course,StartDate,Lenght,Teacher")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(manager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manager);
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Courses.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Course,StartDate,Lenght,Teacher")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manager);
        }

        // GET: Managers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Courses.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manager manager = db.Courses.Find(id);
            db.Courses.Remove(manager);
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
