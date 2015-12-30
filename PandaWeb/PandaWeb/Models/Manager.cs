using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PandaWeb.Models
{
    public class Manager
    {
        [Key]
        public int CourseID { get; set; }
        public string Course { get; set; }
        public DateTime StartDate { get; set; }
        public string Lenght { get; set; }
        public string Teacher { get; set; }
    }
}