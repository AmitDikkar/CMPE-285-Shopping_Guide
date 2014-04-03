using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class UserAccountController : Controller
    {
        public UserDbContext userDbContext = new UserDbContext();
        
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
        // POST: /UserAccount/Login
        [HttpPost]
        public ActionResult Login(User existingUser)
        {
            return View();
        }

        //
        // POST: /UserAccount/Register
        [HttpPost]
        public ActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                userDbContext.users.Add(newUser);
                userDbContext.SaveChanges();
            }

            //TODO: Add view bag message to show Thank you message or sorry already exist message
            //Change this to redirect to same page "Index" method.
            return RedirectToAction("Index","Home");
        }

        //
        // GET: /UserAccount/Register
        public ActionResult Register()
        {
            return View();
        }
    }
}
