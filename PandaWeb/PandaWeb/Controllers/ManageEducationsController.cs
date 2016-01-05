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
    [Authorize]
    public class ManageEducationController : Controller
    {

        private MyDBContext db = new MyDBContext();

        // GET: ManageEducation
        [Authorize(Roles = "A")]
        public ActionResult Index()
        {
            return View(db.EducationPlans.ToList());
        }

        // GET: ManageEducation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationPlan educationPlan = db.EducationPlans.Find(id);
            if (educationPlan == null)
            {
                return HttpNotFound();
            }
            return View(educationPlan);
        }

        // GET: ManageEducation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageEducation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EducationId,Name,StartDate,EndDate,PaceOfStudy,FormOfStudy")] EducationPlan educationPlan)
        {
            if (ModelState.IsValid)
            {
                db.EducationPlans.Add(educationPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educationPlan);
        }

        // GET: ManageEducation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationPlan educationPlan = db.EducationPlans.Find(id);
            if (educationPlan == null)
            {
                return HttpNotFound();
            }
            return View(educationPlan);
        }

        // POST: ManageEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EducationId,Name,StartDate,EndDate,PaceOfStudy,FormOfStudy")] EducationPlan educationPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationPlan).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationPlan);
        }

        // GET: ManageEducation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationPlan educationPlan = db.EducationPlans.Find(id);
            if (educationPlan == null)
            {
                return HttpNotFound();
            }
            return View(educationPlan);
        }

        // POST: ManageEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationPlan educationPlan = db.EducationPlans.Find(id);
            db.EducationPlans.Remove(educationPlan);
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
