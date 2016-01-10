using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PandaWeb
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			// This is the default route for users when a specific url is not provided.
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, 
				namespaces: new[] { "PandaWeb" }
			);

			//routes.MapRoute(
			//    name: "Education",
			//    url: "{controller}/{action}/{id}",
			//    defaults: new { controller = "Education", action = "Backendutveckling", id = "" });
		}
	}
}