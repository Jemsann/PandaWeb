using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandaWeb.Models
{
    [Table("Documents")]
    public class Documents
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Document { get; set; }
        public string DocType { get; set; }
        public string FileName { get; set; }
        public int CourseId { get; set; }
    }
}