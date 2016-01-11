using PandaWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaWeb.ViewModels
{
	public class EduPlanDetailsVM
	{
		public int Id { get; set; }

		[Display(Name = "Namn")]
		public string Name { get; set; }

		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		[Display(Name = "Startdatum")]
		public DateTime StartDate { get; set; }

		[Display(Name ="Slutdatum")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime EndDate { get; set; }

		public ICollection<Course> Courses { get; set; }
	}
}