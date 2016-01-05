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
        public ActionResult Register(User U)
        {
              if (ModelState.IsValid)
            {
                using (UserDbEntities db = new UserDbEntities())
                {
                    db.User.Add(U);
                    db.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Succesfully Regestretion done.";
                }
            }
            return View(U); 
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User U)
        {
            UserDbEntities db = new UserDbEntities();
            var count = db.User.Where(x => x.UserName == U.UserName && x.Password == U.Password).Count();
            if (count == 0)
            {
                ViewBag.Msg = "Invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(U.UserName, false);
                return RedirectToAction("Index", "Home");
            }
         
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    } 
}