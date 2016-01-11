using PandaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using PandaWeb.ViewModels;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace PandaWeb.Controllers
{
	[AllowAnonymous]
	public class EducationController : Controller
	{
		static MyDBContext context = new MyDBContext();
		IRepository repository = new MyDBContextRepository();

		// shows details about educationplan
		public ActionResult UPSystemutveckling(int id)
		{
			return View(repository.GetEducationPlan(id));
		}

		public static string GetMeetingDate()
		{
			string meeting = context.Meeting.Select(m => m.MeetingDate).FirstOrDefault();
			return meeting;
		}

		// Management team view.
		public ActionResult LG()
		{
			return View(repository.GetProtocols());
		}


		//View for students all educations
		public ActionResult EducationsDetails()
		{

			int user = int.Parse(User.Identity.GetUserId());

			return PartialView(repository.GetAllEduPlansViewModel(user));
		}


		//View for specific education
		public ActionResult Details(int id)
		{
			return PartialView(repository.GetEducationPlan(id));
		}

		//public ActionResult Details(int id)
		//{
		//    return PartialView(repository.GetEduPlansDetailsViewModel(id));
		//}


		//view for all courses within an education program
		public ActionResult CourseDetails(int id)
		{
			return PartialView(repository.GetCoursesDetailsViewModel(id));
		}

		//View for showing selected course.
		public ActionResult OneCourseDetails(int id)
		{
			return PartialView(repository.GetCourse(id));
		}
	}
}