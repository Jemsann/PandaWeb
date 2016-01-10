using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaWeb.Models
{
    // C# entity framework class model

    public class EducationPlan
    {
        [Key]
        public int EducationId { get; set; }

        [Required(ErrorMessage = "Ett namn för Utbildningen krävs")]
        // [StringLength(50, ErrorMessage = "{0} måste innehålla minst {2} tecken.", MinimumLength = 4)]
        [Display(Name = "Utbildning")]
        public string Name { get; set; }


        //[Required(ErrorMessage = "Ett Start Datum krävs.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start datum")]
        public DateTime StartDate { get; set; }
        //[Required(ErrorMessage = "Ett Slut Datum krävs.")]
        [Display(Name = "Slut datum")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Studietakt")]
        public string PaceOfStudy { get; set; }
        [Display(Name = "Distans/På plats")]
        public string FormOfStudy { get; set; }

        //länktabell till UL-tabellen
        public virtual UL UL { get; set; }

        //länktabell till kurser
        [Display(Name = "Kurser")]
        public ICollection<Course> Courses { get; set; }

        //länktabell till Utbildningsplan
        public ULDocuments ULDocuments { get; set; }

        public ICollection<Users> UserId { get; set; }
    }
}