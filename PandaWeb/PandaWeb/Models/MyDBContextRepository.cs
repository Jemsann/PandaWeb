using AutoMapper;
using PandaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaWeb.Models;
using System.Web.Mvc;

namespace PandaWeb.Models
{
    public class MyDBContextRepository : IRepository
    {

        ICollection<IndexVM> IRepository.GetIndexViewModel()
        {
            using (var db = new MyDBContext())
            {
                var em = db.EducationPlans;
                var vm = Mapper.Map<ICollection<IndexVM>>(em);
                return vm;
            }
        }

        EduPlanDetailsVM IRepository.GetEduPlansDetailsViewModel(int id)
        {
            using (var db = new MyDBContext())
            {
                var em = db.EducationPlans.SingleOrDefault(ep => ep.EducationId == id);
                em.Courses = db.Course.Where(c => c.EducationPlanId == em.EducationId).ToArray();
                var vm = Mapper.Map<EduPlanDetailsVM>(em);
                return vm;
            }
        }

        ICollection<IndexVM> IRepository.GetCoursesDetailsViewModel(int id)
        {
            using (var db = new MyDBContext())
            {
                var vm = db.Course.Where(cp => cp.EducationPlanId == id).Select(cp => cp);
                var mm = Mapper.Map<ICollection<IndexVM>>(vm);
                return mm;
            }
        }

        Course IRepository.GetCourse(int id)
        {
            using (var db = new MyDBContext())
            {
                return db.Course.SingleOrDefault(c => c.Id == id);
            }
        }

        Course IRepository.GetDocuments(int id)
        {
            using (var db = new MyDBContext())
            {
                var dmodel = db.Course.Where(d => d.Id == id).First();
                return dmodel;
            }
        }

        EducationPlan IRepository.GetEducationPlan(int id)
        {
            using (var db = new MyDBContext())
            {
                var em = db.EducationPlans.SingleOrDefault(ep => ep.EducationId == id);
                em.ULDocuments = db.ULDocuments.SingleOrDefault(c => c.EducationPlanId == id);
                var vm = Mapper.Map<EducationPlan>(em);
                return vm;
            }
        }

        ICollection<Protocol> IRepository.GetProtocols()
        {
            using (var db = new MyDBContext())
            {
                var pro = db.Protocols.Select(pr => pr).ToArray();
                return pro;
            }
        }
        ICollection<Documents> IRepository.GetSpecificDocuments(int id)
        {
            using (var db = new MyDBContext())
            {
                var dmodel = db.Documents.Where(d=>d.CourseId== id).ToArray();
                return dmodel;
            }
        }

		List<SelectListItem> IRepository.GetDropDown()
		{
			var listItems = new List<SelectListItem>();
			MyDBContext context = new MyDBContext();
			var all = from e in context.EducationPlans select e;
			//var all = context.EducationPlans.ToArray();
			foreach (var item in all)
			{
				listItems.Add(new SelectListItem() { Text = item.Name, Value = item.EducationId.ToString() });
			}
			return listItems;
		}



		//    using (var db = new MyDBContext())
		//        {
		//            var em = db.EducationPlans.SingleOrDefault(ep => ep.EducationId == id);
		//em.ULDocuments = db.ULDocuments.Where(ul => ul.EducationPlanId == em.EducationId).First();
		//var vm = Mapper.Map<EducationPlan>(em);
		//            return vm;
		//        }

		//ICollection<Documents> IRepository.GetDocuments(int id)
		//{
		//    using (var db = new MyDBContext())
		//    {
		//        var dmodel = db.Documents.Where(d => d.CourseId == id).Select(d => d);
		//        var cd = Mapper.Map<ICollection<Documents>>(dmodel);
		//        return cd;
		//    }
		//}


		//IndexVM IRepository.GetCoursesDetailsViewModel(int id)
		//{
		//    using (var db = new MyDBContext())
		//    {
		//        var vm = db.Course.SingleOrDefault(cp => cp.EducationPlanId == id);
		//        var mm = Mapper.Map<IndexVM>(vm);
		//        return mm;
		//    }
		//}
	}
}