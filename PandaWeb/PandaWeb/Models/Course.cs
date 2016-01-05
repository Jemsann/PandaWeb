using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandaWeb.Models
{

    [Table("Course")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ett kurs namn krävs")]
        [StringLength(50, ErrorMessage = "{0} måste innehålla minst {2} tecken.", MinimumLength = 4)]
        public string Name { get; set; }
       
        public int EducationPlanId { get; set; }
        [Required(ErrorMessage = "Ett Start Datum krävs.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Ett Slut Datum krävs.")]
        public DateTime EndDate { get; set; }

		public string CoursePlan { get; set; }
        public string EarlierMaterial { get; set; }
        public string OtherMaterial { get; set; }

        //länktabell till studenter
        public ICollection<Student> Students { get; set; }

        //Läraren finns inte i systemet, existerar bara som en prop på en kurs?
        [Required(ErrorMessage = "Ett lärar ID krävs.")]
        public string TeacherId { get; set; }

        //länktabell till utbildning 
        public EducationPlan EducationPlan { get; set; }

        //länk till dokument
        public ICollection<Documents> Documents { get; set; }
    }
}