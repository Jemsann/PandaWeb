using AutoMapper;
using PandaWeb.Models;
using PandaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Optimization;
using System.Web.Routing;

namespace PandaWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        // This runs on app startup. 
        // If you have made changes to the entity framework models you need to initialise a new database.
        // Do this by running the program once with the Database.SetInitializer lines active.
        // Then close the program and comment the lines again to prevent accidental database wipes
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new DropCreateDatabaseAlways<MyDBContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<CalendarContext>());
            //Database.SetInitializer(new MySqlInitializer());

            Mapper.CreateMap<EducationPlan, IndexVM>();
            Mapper.CreateMap<EducationPlan, EduPlanDetailsVM>();
            Mapper.CreateMap<Course, IndexVM>();
            Mapper.CreateMap<Course, Documents>();
            Mapper.CreateMap<EducationPlan, ULDocuments>();
        }
    }
}