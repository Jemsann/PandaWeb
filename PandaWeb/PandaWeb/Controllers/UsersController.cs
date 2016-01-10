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
	// This class is only avaiable to users in role "A"
	[Authorize(Roles = "A")]
	public class UsersController : Controller
	{
		private MyDBContext db = new MyDBContext();

		// List all users
		public ActionResult Index()
		{
			return View(db.Users.ToList());
		}

		// User details
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Users users = db.Users.Find(id);
			if (users == null)
			{
				return HttpNotFound();
			}
			return View(users);
		}

		// Initiate Create user
		public ActionResult Create()
		{
			return View();
		}

		public static List<SelectListItem> GetDropDownForEducations()
		{
			IRepository repo = new MyDBContextRepository();
			return repo.GetDropDownForEducations();
		}

		// Create user in database.
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "UserID,Username,Password,ConfirmPassword,Fullname,Email,Role")] Users users)
		{
			if (ModelState.IsValid)
			{
				db.Users.Add(users);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(users);
		}

		// Initiate edit user.
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Users users = db.Users.Find(id);
			if (users == null)
			{
				return HttpNotFound();
			}
			return View(users);
		}

		// Edit user.
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "UserID,Username,Password,ConfirmPassword,Fullname,Email,Role")] Users users)
		{
			if (ModelState.IsValid)
			{
				db.Entry(users).State = System.Data.Entity.EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(users);
		}

		// Initiate user deletion
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Users users = db.Users.Find(id);
			if (users == null)
			{
				return HttpNotFound();
			}
			return View(users);
		}

		// Delete the user
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Users users = db.Users.Find(id);
			db.Users.Remove(users);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		// Free assets no longer in use
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
