using PandaWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaWeb.ViewModels
{
    public class IndexVM
    {
        public int Id { get; set; }

        public int EducationId { get; set; }

		[Display(Name ="Kurs")]
        public string Name { get; set; }

		[Display(Name ="Startdatum")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime StartDate { get; set; }

		[Display(Name ="Slutdatum")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime EndDate { get; set; }
    }
}