using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class UserAccountController : Controller
    {
        //
        // GET: /UserAccount/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /UserAccount/Login
        public ActionResult Login()
        {
            return View();
        }

        //
        // GET: /UserAccount/Register
        public ActionResult Register()
        {
            return View();
        }
    }
}
