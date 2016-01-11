using PandaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PandaWeb.Controllers
{
	//Allow this class to be accessed by an anonymous user.
	[AllowAnonymous]
	public class AccountController : Controller
	{
		MyDBContext db = new MyDBContext();
		// Register account
		public ActionResult Register()
		{
			return View();
		}

		// The informmation posted by the user is handeld, the role set to "Student" and the user registered in the database.
		//This action only handels post requests.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register([Bind(Include = "UserID,EducationId,Username,Password,ConfirmPassword,Fullname,Email,Role")] Users users)
		{
			if (ModelState.IsValid)
			{
				users.Role = "S";
				db.Users.Add(users);

				db.SaveChanges();
				ViewBag.Message = "Användare registrerad";
			}

			//db.SaveChanges();
			return View(users);
		}

		//The user login action.
		public ActionResult Login()
		{
			return View();
		}

		// Handels the post-request from the login form. If a username with matching password exsits the user is loged in and redirected to the Home-controller
		// index-action.
		[HttpPost]
		public ActionResult Login(Users U)
		{
			MyDBContext db = new MyDBContext();
			var count = db.Users.Where(x => x.Username == U.Username && x.Password == U.Password).Count();
			if (count == 0)
			{
				ViewBag.Msg = "Felaktigt användarnamn eller lösenord, försök igen.";
				return View();
			}
			else
			{
				FormsAuthentication.SetAuthCookie(U.Username, false);
				return RedirectToAction("Index", "Home");
			}

		}

		// User log out
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}

		// Produces a list of all users with the role "L" which is then passed to the view.
		public ActionResult Lgusers()
		{
			MyDBContext db = new MyDBContext();
			var role = (from r in db.Users where r.Role.Contains("L") select r).ToList();

			return View(role);

		}

		// This shows the courses and educationprograms the loged in student are attending.
		public ActionResult MyEducations()
		{
			return View();
		}
	}
}