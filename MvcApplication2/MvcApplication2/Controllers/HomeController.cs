using MvcApplication2.Helpers;
using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        ShoppingDbContext shoppingDb = new ShoppingDbContext();
        //Home/
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            IQueryable<Product> electronics = (from item in shoppingDb.products where item.Type == "electronics" select item).Take(3);
            IQueryable<Product> equips = (from item in shoppingDb.products where item.Type == "healthandbeauty" select item).Take(3);
            List<Product> displayList = new List<Product>();
            displayList.AddRange(electronics);
            displayList.AddRange(equips);
            return View(displayList);
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

        //
        //POST: /UserAccount/sendFeedback
        [HttpPost]
        public ActionResult sendFeedback()
        {
            //extract form data
            String userName = Request["name"].ToString();
            String email = Request["email"].ToString();
            String subject = Request["subject"].ToString();
            String messageText = Request["messageText"].ToString();

            if (userName == "" || email == "" || subject == "" || messageText == "")
            {
                TempData["ValidationMessage"] = "Please provide correct input";
                return RedirectToAction("Contact");
            }
            else
            {
                API api = new API();
                api.sendFeedback(email, subject, userName);
                TempData["FeedbackMessage"] = "We have Received your feedback. Thank You!!";
            }
            //send email
            return RedirectToAction("Contact");
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
