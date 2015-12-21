using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace PandaWeb.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("MyDBContext")
        {

        }

        public DbSet<EducationPlan> EducationPlans { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<UL> UL { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<LG> LG { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<ULDocuments> ULDocuments { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
    }
}