using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StepOneEducation_1_0
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Ignore route statements
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");//for the Web resource files (e.g., scripts, styles);
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}"); //or the ASHX handler, which processes the file upload functionality of DevExpress ASP.NET MVC extensions (e.g., UploadControl, FileManager, HtmlEditor).

            //Route Defination
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    "HighSchool",
            //    "HighSchool/{name}",
            //    new { controller = "HighSchool", action = "Index", name = UrlParameter.Optional}
                
            //    );

        }
    }
}
