using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PandaWeb.Models
{
    public class PopulateDBWithEducationPlan
    {
        MyDBContext context = new MyDBContext();
        public PopulateDBWithEducationPlan()
        {
            CreateBackendutveckling();
            CreateSystemutveckling();
            CreateCourseOne();
        }
        public void CreateBackendutveckling()
        { 
                var eduPlan = new EducationPlan();
                eduPlan.Name = "Backendutveckling";
                eduPlan.StartDate =
                    new DateTime(2015, 01, 01);
                eduPlan.EndDate = new DateTime(2016, 12, 30);
                context.EducationPlans.Add(eduPlan);
                context.SaveChanges();
        }

        public void CreateSystemutveckling()
        {
            var eduPlan = new EducationPlan();
            eduPlan.Name = "Systemutveckling";
            eduPlan.StartDate =
                new DateTime(2015, 01, 01);
            eduPlan.EndDate = new DateTime(2016, 12, 30);

            context.EducationPlans.Add(eduPlan);
            context.SaveChanges();
        }


        public void CreateCourseOne()
        {
            Course course = new Course();
            course.Name = "OO1";
            course.EducationPlanId = 2;

            context.Course.Add(course);
            context.SaveChanges();
        }

        public void CreateCourseTwo()
        {
            Course course2 = new Course();
            course2.Name = "OO2";
            course2.EducationPlanId = 2;

            context.Course.Add(course2);
            context.SaveChanges();
        }
    }
}