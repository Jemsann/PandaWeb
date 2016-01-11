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
    //This class is only available to users in role "A"
	[Authorize(Roles ="A")]
    public class CoursesController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // Shows the current set of classes stored in the database
        public ActionResult Index()
        {
            return View(db.Course.ToList());
        }

        // Shows information about a specific course. The parameter is used as a courseID.
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
			
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // This allows a user to create a new course.
        public ActionResult Create()
        {
            return View();
        }

        // Handels the post-request from a user trying to create a course.
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EducationPlanId,StartDate,EndDate")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Course.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }


		public static List<SelectListItem> GetDropDownEdu()
		{
			var listItems = new List<SelectListItem>();
			MyDBContext context = new MyDBContext();
			//var all = from e in context.EducationPlans select e;
			var all = context.EducationPlans.Select(e => e);
			//EducationPlan[] all = context.EducationPlans.ToArray();
			if (all != null)
			{
				foreach (var item in all)
				{
					listItems.Add(new SelectListItem() { Text = item.Name, Value = item.EducationId.ToString() });
				}
			}
			else
			{
				listItems.Add(new SelectListItem() { Text = "Systemutveckling", Value = 1.ToString() });
				listItems.Add(new SelectListItem() { Text = "Backendutveckling", Value = 2.ToString() });
			}
			return listItems;
		}

		// Lets a user edit a stored course.
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // Saves the edited course back to the database.
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EducationPlanId,CoursePlan,EarlierMaterial,OtherMaterial,TeacherId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // Initiate deletion of specified course from the database.
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // Delete specified course from the database.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Course.Find(id);
            db.Course.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // This will free up assets which are no longer in use.
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
