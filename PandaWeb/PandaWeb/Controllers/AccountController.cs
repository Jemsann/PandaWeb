using PandaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PandaWeb.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Users U)
        {
              if (ModelState.IsValid)
            {
                using (MyDBContext db = new MyDBContext())
                {
                    U.Role = "S";
                    db.Users.Add(U);
                    db.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Succesfully Registration Done!";
                }
            }
            return View(U); 
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users U)
        {
            MyDBContext db = new MyDBContext();
            var count = db.Users.Where(x => x.Username == U.Username && x.Password == U.Password).Count();
            if (count == 0)
            {
                ViewBag.Msg = "Invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(U.Username, false);
                return RedirectToAction("Index", "Home");
            }
         
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Lgusers()
        {
            MyDBContext db = new MyDBContext();
            var role = (from r in db.Users where r.Role.Contains("L") select r).ToList();
            return View(role);

        }

        public ActionResult MyCourses()
        {

            return View();
        }
    } 
}