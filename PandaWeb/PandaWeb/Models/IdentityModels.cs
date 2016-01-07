﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PandaWeb.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser
	// class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
	UserManager<ApplicationUser> manager)
		{

			var userIdentity =
				await manager.CreateIdentityAsync(this,
					DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}


	public class ApplicationContext : IdentityDbContext<ApplicationUser>
	{
		static ApplicationContext()
		{
			//Database.SetInitializer(new MySqlInitializer());
		}

		public ApplicationContext()
		  : base("MyDBContext")
		{
		}
		public static ApplicationContext Create()
		{
			return new ApplicationContext();
		}
	}
}