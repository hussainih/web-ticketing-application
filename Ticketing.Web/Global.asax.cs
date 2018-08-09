using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ticketing;

[assembly: PreApplicationStartMethod(typeof(MvcApplication), "Register")]
namespace Ticketing
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void Register()
        {
            HttpApplication.RegisterModule(typeof(LogModule));
        }

        public void Application_PreRequestHandlerExecute()
        {
            Debug.WriteLine("Current Dependency Resolver: " + System.Web.Mvc.DependencyResolver.Current.GetType().Name);
            Debug.WriteLine("Current Controller Factory: " + ControllerBuilder.Current.GetControllerFactory().GetType().Name);
        }
        protected void Application_Start()
        {
             AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           
        }
        protected void Application_BeginRequest(Object source, EventArgs e)
        {
            string culture = "de-DE";
            if (HttpContext.Current.Request.RequestContext.RouteData != null)
            {
               //get the culture value which is stored in Rout for "lang" variable
                HttpContextBase currentContext = new HttpContextWrapper(HttpContext.Current);
                RouteData routeData = RouteTable.Routes.GetRouteData(currentContext);
                if(routeData.Values["lang"] != null) {
                    culture = routeData.Values["lang"].ToString();
                }
                else
                {
                    culture = "de-DE";
                }
                 
                //TODO code to get the culture values from Cookie
                //TODO code to get the culture values sent by browser
                //set the culture on current thread
               
            }
            
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);




        }
    }
}
