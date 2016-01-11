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
	// C# entity framework context class
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

		EducationPlan IRepository.GetAllEduPlansViewModel(int userId)
		{
			using (var db = new MyDBContext())
			{
				int cm = db.Users.Where(user => user.UserID == userId).Select(user => user.EducationId).FirstOrDefault();
				var em = db.EducationPlans.Where(ep => ep.EducationId == cm).FirstOrDefault();
				return em;
			}
		}

		List<SelectListItem> IRepository.GetDropDownForEducations()
		{
			var listItems = new List<SelectListItem>();
			MyDBContext context = new MyDBContext();
			var em = context.EducationPlans.ToArray();
			foreach (var item in em)
			{
				listItems.Add(new SelectListItem() { Text = item.Name, Value = item.EducationId.ToString() });
			}
			return listItems;
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

		//EducationPlan IRepository.GetEducations(int id)
		//{
		//	using (var db = new MyDBContext())
		//	{
		//		var dmodel = db.EducationPlans.Where(d => d.UserId == id).First();
		//		return dmodel;
		//	}
		//}

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
				var dmodel = db.Documents.Where(d => d.CourseId == id).ToArray();
				return dmodel;
			}
		}

		List<SelectListItem> IRepository.GetDropDown()
		{
			var listItems = new List<SelectListItem>();
			MyDBContext context = new MyDBContext();
			var all = from e in context.EducationPlans select e;
			//EducationPlan[] all = context.EducationPlans.ToArray();
			if (all != null)
			{
				foreach (var item in all)
				{
					listItems.Add(new SelectListItem() { Text = item.Name, Value = item.EducationId.ToString() });
				}
			}
			else
			{
				listItems.Add(new SelectListItem() { Text = "Systemutveckling", Value = 1.ToString() });
				listItems.Add(new SelectListItem() { Text = "Backendutveckling", Value = 2.ToString() });
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