using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class CartController : Controller
    {

        public ShoppingDbContext myCartContext = new ShoppingDbContext();
        //
        // GET: /Cart/
        [MvcApplication2.MvcApplication.IfSessionAvailable]
        public ActionResult Index()
        {
            IQueryable<Cart> carts =null;
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
                Session["CurrentCartTotal"] = total;
                Session["CurrentCartCount"] = carts.Count();
            }
            return View(carts.ToList());
        }

        [MvcApplication2.MvcApplication.IfSessionAvailable]
        [HttpPost]
        public ActionResult MyCart(int quantity = 0)
        {
            int qt=1;
            //take quantity entered by the user
            String str = Request.Form["quantity"];

            if (str.Length >= 1)
            {
                try
                {
                    qt = Convert.ToInt32(str);
                }
                catch (Exception e)
                {
                    ViewBag.Comment = "Please enter valid number as quantity";
                    Response.Redirect(Session["CurrentUrl"].ToString());
                }
            }
            else
            {
                qt = 1;
            }

            //take product Id
            string p = Request.Form["ProductID"];
            int productID = Convert.ToInt32(p);
            
            //take user Id
            if (Session["LoggedUser"] != null)
            {
                int userID = (int)Session["LoggedUser"];
                AddToMyCart(qt, productID, userID);
            }

            //redirect to index action of same controller to show list of cart items
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Add item to the cart from products index page
        /// quantity will always be 1
        /// </summary>
        /// <returns></returns>

        //
        //GET: /Cart/MyCart/
        [HttpGet]
        public ActionResult MyCartGET(int productID = 1)
        {
            int userID;
            if (Session["LoggedUser"] != null)
            {
                userID = (int)Session["LoggedUser"];
                AddToMyCart(1, productID, userID);
                return RedirectToAction("Index");
            }
            else
            {
                //Session["ReturnUrl"] = Session["CurrentUrl"].ToString();
                Session["ReturnUrl"] = "/Cart/MyCartGET?productID=" + productID.ToString();
                TempData["LoginComment"] = "You need to register in order to add chosen item in cart";
                return RedirectToAction("Login", "UserAccount");
            }
        }


        //
        //POST: /carts/UpdateQuantity
        public ActionResult UpdateQuantity(string operation, int cartID)
        {
            //we have a unique row for every item in the cart, hence we don't need product id to choose operate on quantity
            switch (operation)
            {
                case "add":
                    incrementQuantity(cartID);
                    break;
                case "sub":
                    decrementQuanity(cartID);
                    break;
                case "del":
                    removeQuantity(cartID);
                    break;
                default:
                    //RedirectToAction("Index", "Cart");
                    break;
            }
            return RedirectToAction("Index", "Cart");
        }

        /// <summary>
        /// This method is a common method for adding an item in the cart
        /// </summary>
        /// <param name="qt"></param>
        /// <param name="productId"></param>
        /// <param name="userID"></param>

        [NonAction]
        public void AddToMyCart(int qt, int productID, int userID)
        {
            //check if this user has added the same item in cart before
            Cart existingCart = (from item in myCartContext.carts where item.userID == userID & item.productID == productID & item.billed == false select item).FirstOrDefault();
            if (existingCart == null)
            {
                //creat a new row for carts table
                Cart newCartItem = new Cart();
                newCartItem.productID = productID;
                newCartItem.quantity = qt;
                newCartItem.userID = userID;
                //newCartItem.User = (from item in myCartContext.users where item.ID == userID select item).FirstOrDefault();
                newCartItem.billed = false;

                myCartContext.carts.Add(newCartItem);
                myCartContext.SaveChanges();
            }
            else
            {
                existingCart.quantity = existingCart.quantity + qt;
                myCartContext.SaveChanges();
            }
        }

        [NonAction]
        private void removeQuantity(int cartID)
        {
            Cart cart = (from item in myCartContext.carts where item.ID == cartID select item).SingleOrDefault();

            //update this item
            myCartContext.carts.Remove(cart);

            //save the database
            myCartContext.SaveChanges();
        }

        [NonAction]
        private void decrementQuanity(int cartID)
        {
            Cart cart = (from item in myCartContext.carts where item.ID == cartID select item).SingleOrDefault();

            //update this item
            cart.quantity--;
            if (cart.quantity <= 0)
            {
                myCartContext.carts.Remove(cart);
            }
            //save the database
            myCartContext.SaveChanges();
        }

        [NonAction]
        private void incrementQuantity(int cartID)
        {
            //there will be exactly one cart row for each cartID
            Cart cart = (from item in myCartContext.carts where item.ID == cartID select item).SingleOrDefault();
            
            //update this item
            cart.quantity++;

            //save the database
            myCartContext.SaveChanges();
        }
    }
}
