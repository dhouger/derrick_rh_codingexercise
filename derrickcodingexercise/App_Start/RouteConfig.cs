using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace derrickcodingexercise
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "CodingExercise", action = "Square", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Poll",
				url: "{controller}/{action}/{male}/{female}",
				defaults: new { controller = "CodingExercise", action = "Gender", male = UrlParameter.Optional, female = UrlParameter.Optional }
				);
		}
	}
}
