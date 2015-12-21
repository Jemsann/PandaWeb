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

namespace PandaWeb.Controllers
{
    public class EducationController : Controller
    {
        MyDBContext context = new MyDBContext();

        //Första gången du kör koden, så måste du instansiera upp PopulateDBWithEducationPlan
        //och du måste trycka på endast!! en av länkarna i HomeControllern för utbildnignarna, 
        //därefter stänga och köra om, men
        //med nedan rad bortkommenterad!!
        //PopulateDBWithEducationPlan fillDB = new PopulateDBWithEducationPlan();
        //I mappen Global.asax.cs kommentera bort Database.SetInitializer

        // GET: UP
        public ActionResult UPSystemutveckling(int id)
        {
            return View(repository.GetEducationPlan(id));
        }

        public ActionResult LG()
        {
            //ActionResult för LG-Information
            return View(repository.GetProtocols());
        }
        IRepository repository = new MyDBContextRepository();

        //Vy för utbildningar
        public ActionResult Details(int id)
        {    
            return PartialView(repository.GetEducationPlan(id));
        }

        //public ActionResult Details(int id)
        //{
        //    return PartialView(repository.GetEduPlansDetailsViewModel(id));
        //}


        //Vy för alla kurser för specifik utbildning
        public ActionResult CourseDetails(int id)
        {
            return PartialView(repository.GetCoursesDetailsViewModel(id));
        }

        //Vy för specifik kurs
        public ActionResult OneCourseDetails(int id)
        {
            return PartialView(repository.GetCourse(id));
        }
    }
}