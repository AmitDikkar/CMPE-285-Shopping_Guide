using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcApplication2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        public class IfSessionAvailableAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpContext ctx = HttpContext.Current;
                if (ctx.Session != null)
                {
                    //string current = Request.Path.ToString();
                    if (ctx.Session["LoggedUser"] == null)
                    {
                        if (ctx.Session["CurrentUrl"] != null)
                        {
                            ctx.Session["ReturnUrl"] = ctx.Session["CurrentUrl"];
                        }
                        else
                        {
                            //this is added to fix the temporary navigation to the login and from there to the cart
                            //not the fixed solution, just a patch
                            ctx.Session["ReturnUrl"] = "/Cart/Index";
                        }
                        ctx.Response.Redirect("/UserAccount/Login/", true);
                    }
                }
                else
                {
                    ctx.Session["ReturnUrl"] = ctx.Session["CurrentUrl"];
                    ctx.Response.Redirect("/UserAccount/Login/", true);
                }
            }
        }
    }
}