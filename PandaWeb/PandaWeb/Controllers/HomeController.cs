﻿using AutoMapper;
using PandaWeb.Models;
using PandaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWeb.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{

		public ActionResult Index()
		{
			return View();
		}

		[Authorize(Roles = "S"), Authorize(Roles = "A")]
		public ActionResult Edu()
		{
			MyDBContext context = new MyDBContext();
			var all = (from e in context.EducationPlans select e);
			return PartialView(Mapper.Map<ICollection<IndexVM>>(all));
		}

		public ActionResult About()
		{
			ViewBag.Message = "Om PandaWebb.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Kontakta oss.";

			return View();
		}
	}
}