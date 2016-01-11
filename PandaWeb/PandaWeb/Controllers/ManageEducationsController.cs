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
	// This class is only available to users in role "A"
	[Authorize(Roles = "A")]
	public class ManageEducationController : Controller
	{

		private MyDBContext db = new MyDBContext();

		// view for admin to list, create, delete and edit educationplans.
		public ActionResult Index()
		{
			return View(db.EducationPlans.ToList());
		}

		// Returns the selected educationplan
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

		// Create new educationplan
		public ActionResult Create()
		{
			return View();
		}

		// Creating the new educationplan.
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

		// Retrives educationplan for edit.
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

		// Saves the edited educationplan.
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

		// initiate deletetion of educationplan.
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

		// deletes educationplan and saves changes to database
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			EducationPlan educationPlan = db.EducationPlans.Find(id);
			db.EducationPlans.Remove(educationPlan);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult EditMeetingDate(int id)
		{
			Meeting meeting = db.Meeting.FirstOrDefault();
			if (meeting == null)
			{
				return HttpNotFound();
			}
			return View(meeting);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditMeetingdate([Bind(Include = "Id, MeetingDate")] Meeting meeting)
		{
			if (ModelState.IsValid)
			{
				db.Entry(meeting).State = System.Data.Entity.EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(meeting);
		}


		// this will free up assets which are no longer in use.
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
