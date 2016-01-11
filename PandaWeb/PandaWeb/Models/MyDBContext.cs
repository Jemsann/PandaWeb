using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PandaWeb.Models
{
	// C# entity framework context class.

	[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
	public class MyDBContext : DbContext
	{
		public MyDBContext() : base("MyDBContext")
		{

		}

		static MyDBContext()
		{
			DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
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
		public DbSet<Users> Users { get; set; }
		public DbSet<Meeting> Meeting { get; set; }
	}
}