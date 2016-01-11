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
using System.Web.Security;

namespace PandaWeb.Controllers
{
    
    public class EducationController : Controller
    {
        MyDBContext context = new MyDBContext();
        
        // shows details about educationplan
        public ActionResult UPSystemutveckling(int id)
        {
            return View(repository.GetEducationPlan(id));
        }

		

        // Management team view.
        public ActionResult LG()
        {            
            return View(repository.GetProtocols());
        }
        IRepository repository = new MyDBContextRepository();

		//View for students all educations
		public ActionResult EducationsDetails()
		{
            //var userId = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;

            ////return PartialView(repository.GetEducationPlan(userId));

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