using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PandaWeb.Models
{
    public class EducationPlan
    {
        [Key]
        public int EducationId { get; set; }
        [Required(ErrorMessage = "Ett namn för Utbildningen krävs")]
        [StringLength(50, ErrorMessage = "{0} måste innehålla minst {2} tecken.", MinimumLength = 4)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ett Start Datum krävs.")]
        [DisplayFormat(DataFormatString="{0:yyyy/MM/dd}")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Ett Slut Datum krävs.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime EndDate { get; set; }
        public string PaceOfStudy { get; set; }
        public string FormOfStudy { get; set; }

        //länktabell till UL-tabellen
        public virtual UL UL { get; set; }

        //länktabell till kurser
        public ICollection<Course> Courses { get; set; }

        //länktabell till Utbildningsplan
        public ULDocuments ULDocuments { get; set; }
    }
}