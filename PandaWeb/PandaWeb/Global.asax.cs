using AutoMapper;
using PandaWeb.Models;
using PandaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PandaWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer(new DropCreateDatabaseAlways<MyDBContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<CalendarContext>());

            Mapper.CreateMap<EducationPlan, IndexVM>();
            Mapper.CreateMap<EducationPlan, EduPlanDetailsVM>();
            Mapper.CreateMap<Course, IndexVM>();
            Mapper.CreateMap<Course, Documents>();
            Mapper.CreateMap<EducationPlan, ULDocuments>();
        }
    }
}