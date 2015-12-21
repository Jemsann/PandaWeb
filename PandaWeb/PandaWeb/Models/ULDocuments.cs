using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWeb.Models
{
    public class ULDocuments
    {
        public int Id { get; set; }
        public byte[] Document { get; set; }
        public string DocType { get; set; }
        public string FileName { get; set; }
        public int EducationPlanId { get; set; }
    }
}