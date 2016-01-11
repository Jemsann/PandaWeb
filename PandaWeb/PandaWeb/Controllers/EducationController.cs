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
			int user;
			int userEdu;
			string name = User.Identity.Name;
			
			using (var db = new MyDBContext())
			{
				user = db.Users.Where(u => u.Username == name).Select(u => u.UserID).FirstOrDefault();
				userEdu = db.Users.Where(u => u.UserID == user).Select(u => u.EducationId).FirstOrDefault();		
			}
			//return PartialView(repository.GetEduPlansDetailsViewModel(userEdu));
			return PartialView(repository.GetEduPlan(user));
		}


		//View for specific education
		public ActionResult Details(int id)
		{
			return View(repository.GetEducationPlan(id));
		}

		//public ActionResult Details(int id)
		//{
		//    return PartialView(repository.GetEduPlansDetailsViewModel(id));
		//}


		//view for all courses within an education program
		public ActionResult CourseDetails(int id)
		{
			//return Content("<div>!</div>");
			return PartialView(repository.GetCoursesDetailsViewModel(id));
		}

		//View for showing selected course.
		public ActionResult OneCourseDetails(int id)
		{
			return PartialView(repository.GetCourse(id));
		}
	}
}