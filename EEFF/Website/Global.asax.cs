using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;

namespace Website
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebsiteApplication : HttpApplication
    {
        public static ICommandService TheCommandService
        {
            get { return (ICommandService) HttpContext.Current.Application["CommandService"]; }
            set { HttpContext.Current.Application["CommandService"] = value;  }
        }

        public static void InitializeEnvironment()
        {
            BootStrapper.BootUp();

            TheCommandService = NcqrsEnvironment.Get<ICommandService>();
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            InitializeEnvironment();
        }
    }
}