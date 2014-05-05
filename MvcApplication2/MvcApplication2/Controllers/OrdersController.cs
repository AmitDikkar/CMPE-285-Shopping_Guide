using MvcApplication2.Helpers;
using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class OrdersController : Controller
    {
        //
        // GET: /Orders/
        public ShoppingDbContext myCartContext = new ShoppingDbContext();

        [MvcApplication2.MvcApplication.IfSessionAvailable]
        public ActionResult Index()
        {
            IQueryable<Cart> carts = null;
            if (Session["LoggedUser"] != null)
            {
                int userID = Convert.ToInt32(Session["LoggedUser"].ToString());

                carts = (from item in myCartContext.carts where item.userID == userID & item.billed == false select item);
                float total = 0;
                foreach (Cart c in carts)
                {
                    total = total + c.total;
                }
                ViewBag.total = total;
            }
            if (carts != null)
            {
                return View(carts.ToList());
            }
            else
            {
                return View();
            }
        }

        //
        //POST: /Orders/PlaceOrder
        [HttpPost]
        [MvcApplication2.MvcApplication.IfSessionAvailable]
        public ActionResult PlaceOrder()
        {
            //take out all values of form
            string apartmentNo;
            string street;
            string state;
            string country;
            string postCode;

            if (Request["apartmentNo"] != null && Request["street"] != null && Request["state"] != null && Request["country"] != null && Request["postCode"] != null)
            {
                apartmentNo = Request["apartmentNo"];
                street = Request["street"];
                state = Request["state"];
                country = Request["country"];
                postCode = Request["postCode"];
            }
            else
            {
                ViewBag.AddressError = "Address you have entered is not valid";
                return RedirectToAction("Index");
            }

            int userID = Convert.ToInt32(Session["LoggedUser"].ToString());
            IQueryable<Cart> carts = (from item in myCartContext.carts where item.userID == userID & item.billed == false select item);
            foreach (Cart c in carts.ToList())
            {
                c.billed = true;
            }
            myCartContext.SaveChanges();

            //send an email here stating the address

            //update session variables
            Session["CurrentCartCount"] = null;
            Session["CurrentCartTotal"] = null;
            API api = new API();
            api.sendEmail("amit.dikkar@gmail.com", "plcaeOrder", carts.ToList());
            string userEmail = (from item in myCartContext.users where item.ID == userID select item.email).FirstOrDefault();
            TempData["orderStatus"] = "Your order has been placed successfully. Confirmation email has been sent to: "+userEmail;
            return RedirectToAction("Index");
        }

        //
        //GET: /Orders/OrderHistory
        public ActionResult OrderHistory()
        {
           // OrderHistoryViewModel viewModel = new OrderHistoryViewModel();
            List<Cart> ordersList = null;
            if (Session["LoggedUser"] == null)
            {
                Session["ReturnUrl"] = "/Orders/OrderHistory/";
                RedirectToAction("Login", "UserAccount");
            }
            else
            {
                int userID = (int) Session["LoggedUser"];
                //IQueryable<Cart> cartsList = (from item in myCartContext.carts where item.userID == userID & item.billed == false select item);
                IQueryable<Cart> cartsList = (from item in myCartContext.carts where item.userID == userID & item.billed == true select item);
                //viewModel.cartsList = cartsList.ToList();
                ordersList = cartsList.ToList();

                float total = 0;
                    foreach (Cart c in ordersList)
                    {
                        total = total + c.total;
                    }
                    ViewBag.total = total;
                
            }
            return View(ordersList);
        }
    }
}
