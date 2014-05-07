using MvcApplication2.Helpers;
using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class UserAccountController : Controller
    {
        public ShoppingDbContext userDbContext = new ShoppingDbContext();
        
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
        //GET: /UserAccount/Logout/
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /UserAccount/Login
        [HttpPost]
        public ActionResult Login(User existingUser)
        {
            string email = existingUser.email;
            string passwd = existingUser.password;

            if (existingUser.email == "" || existingUser.password == "")
            {
                ViewBag.LoginComment = "Please enter all values before login";
                return View();
            }
            
            if (ModelState.IsValid)
            {
                var check = (from item in userDbContext.users where item.email == existingUser.email & item.password==existingUser.password select item).FirstOrDefault();

                //if credentials not found
                if (check == null)
                {
                    ViewBag.comment = "Sorry. We can not find your credentials";
                    return View();
                }
                    //if credentials found
                else
                {
                    User user = (User)check;
                    Session["LoggedUserName"] = user.firstName;
                    Session["LoggedUser"] = user.ID;
                    //Session["CurrentCartCount"] = user.carts.Count();

                    IQueryable<Cart> userCarts = (from item in userDbContext.carts where item.userID == user.ID & item.billed == false select item);
                    Session["CurrentCartCount"] = userCarts.Count();
                    float total = 0;
                    //find total cart price value
                    foreach (Cart c in userCarts)
                    {
                        total = total + c.total;
                    }
                    Session["CurrentCartTotal"] = total;

                    //if user has not been redirected from somewhere else
                    if (Session["ReturnUrl"] == null)
                    {
                        ViewBag.comment = "You have successfully logged in";
                        return RedirectToAction("Index", "Home");
                    }
                        //if user has been redirected from somewhere else, then
                        //then send him to the same place from where he came using return url of the session
                    else
                    {
                        string returnUrl = Session["ReturnUrl"].ToString();
                        Session["ReturnUrl"] = null;
                        return Redirect(returnUrl);
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /UserAccount/Register
        [HttpPost]
        public ActionResult Register(User newUser)
        {
            try
            {

                if (newUser.email == "" || newUser.password == "" || newUser.firstName == "" || newUser.lastName == "")
                {
                    TempData["RegistrationComment"] = "One of the field is left blank";
                    return View();
                }
                if (ModelState.IsValid)
                {
                    //String query = "select * from Users where email=" + "\"" + newUser.email + "\""+";";
                    //var user =  userDbContext.users.Where(u => u.email == newUser.email).SingleOrDefault();
                    var user = userDbContext.users.SqlQuery("select * FROM users WHERE email = @p0", newUser.email).FirstOrDefault();

                    if (user == null)
                    {
                        userDbContext.users.Add(newUser);
                        userDbContext.SaveChanges();
                        TempData["RegistrationComment"] = "You have successfully Registered to BootShop. Please login now";
                        API api = new API();
                        api.sendRegistrationEmail(user);
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        TempData["RegistrationComment"] = "User with this email id already exist";
                        return RedirectToAction("Register");
                    }
                }
                else
                {
                    TempData["RegistrationComment"] = "Please try again, Something went wrong";
                    return View();
                }
            }
            catch (System.Exception e)
            {
                TempData["RegistrationComment"] = e.Message;
                return View();
            }
            
        }

        //
        // GET: /UserAccount/Register
        public ActionResult Register()
        {
            return View();
        }
    }
}
    