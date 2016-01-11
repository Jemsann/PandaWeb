using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandaWeb.Models
{
    // C# entity framework class model

    [Table("Course")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ett kursnamn krävs")]
        [StringLength(50, ErrorMessage = "{0} måste innehålla minst {2} tecken.", MinimumLength = 4)]
        [Display(Name = "Kurs")]
        public string Name { get; set; }
        [Display(Name = "Utbildnings ID")]
        public int EducationPlanId { get; set; }

		[Required(ErrorMessage = "Ett Startdatum krävs.")]
        [Display(Name = "Kurs start")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime StartDate { get; set; }

		[Required(ErrorMessage = "Ett Slutdatum krävs.")]
        [Display(Name = "Kurs slut")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime EndDate { get; set; }

		[Display(Name = "Kurs plan")]
        public string CoursePlan { get; set; }
        [Display(Name = "Tidigare material")]
        public string EarlierMaterial { get; set; }
        [Display(Name = "Övrigt material")]
        public string OtherMaterial { get; set; }

        //länktabell till studenter
        public ICollection<Student> Students { get; set; }

       
        //länktabell till utbildning 
        [Display(Name = "Utbildnings plan")]
        public EducationPlan EducationPlan { get; set; }

        //länk till dokument
        [Display(Name = "Dokument")]
        public ICollection<Documents> Documents { get; set; }
    }
}