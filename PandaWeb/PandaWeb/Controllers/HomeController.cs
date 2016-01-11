using AutoMapper;
using PandaWeb.Models;
using PandaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWeb.Controllers
{
	// Allows anonymous users to use this class.
	[AllowAnonymous]
	public class HomeController : Controller
	{
		// The default start page
		public ActionResult Index()
		{
			return View();
		}

		//// If loged in shows a list of all educations
		//[Authorize(Roles = "S"), Authorize(Roles = "A")]
		//public ActionResult Edu(int id)
		//{
		//	MyDBContext context = new MyDBContext();
		//	var allEdu;
		//	return PartialView(Mapper.Map<ICollection<IndexVM>>(all));
		//}

		//// If loged in shows a list of all educations
		//[Authorize(Roles = "S"), Authorize(Roles = "A")]
		//public ActionResult Edu()
		//{
		//	MyDBContext context = new MyDBContext();
		//	var all = (from e in context.EducationPlans select e);
		//	return PartialView(Mapper.Map<ICollection<IndexVM>>(all));
		//}

		// About
		public ActionResult About()
		{
			ViewBag.Message = "Om PandaWebb.";

			return View();
		}

		// Contact
		public ActionResult Contact()
		{
			ViewBag.Message = "Kontakta oss.";

			return View();
		}
	}
}