﻿using System;
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
        public string Name { get; set; }
        public List<String> Courses { get; set; }

        [DisplayFormat(DataFormatString="{0:yyyy/MM/dd}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime EndDate { get; set; }
        public string PaceOfStudy { get; set; }
        public string FormOfStudy { get; set; }
    }
}