using PandaWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PandaWeb.Models
{
    interface IRepository
    {
        ICollection<IndexVM> GetIndexViewModel();
        EduPlanDetailsVM GetEduPlansDetailsViewModel(int id);
        ICollection<IndexVM> GetCoursesDetailsViewModel(int id);
        Course GetCourse(int id);
        Course GetDocuments(int id);
        EducationPlan GetEducationPlan(int id);
        ICollection<Protocol> GetProtocols();
        ICollection<Documents> GetSpecificDocuments(int id);
		List<SelectListItem> GetDropDown();

	}
}
