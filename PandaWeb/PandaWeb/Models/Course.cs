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

        [Required]
        public string Name { get; set; }
       
        public int EducationPlanId { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public string CoursePlan { get; set; }
        public string EarlierMaterial { get; set; }
        public string OtherMaterial { get; set; }

        //länktabell till studenter
        public ICollection<Student> Students { get; set; }

        //Läraren finns inte i systemet, existerar bara som en prop på en kurs?
        public string TeacherId { get; set; }

        //länktabell till utbildning 
        public EducationPlan EducationPlan { get; set; }

        //länk till dokument
        public ICollection<Documents> Documents { get; set; }
    }
}