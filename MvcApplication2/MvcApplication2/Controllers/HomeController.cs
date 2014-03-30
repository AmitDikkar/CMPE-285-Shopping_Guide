using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Returns Special_Offer view
        /// </summary>
        /// <returns></returns>
        public ActionResult specialOffer()
        {
            ViewBag.Message = "This is special offers page";
            
            return View();
        }

        /// <summary>
        /// Returns Normal view
        /// </summary>
        /// <returns></returns>
        public ActionResult Normal()
        {
            ViewBag.Message = "This is Delivery Page";
            
            return View();
        }
    }
}
