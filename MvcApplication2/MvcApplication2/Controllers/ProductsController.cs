using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class ProductsController : Controller
    {

        ShoppingDbContext shoppingDb = new ShoppingDbContext();
        //
        // GET: /Products/
        //Returns the requested product list
        public ActionResult Index(string productType = "electronics", string productSubtype = "camera")
        {
            //if user has not provided product type or productSubtype then by default it will be elctronics-camera
            IQueryable<Product> products = (from item in shoppingDb.products where item.Type == productType & item.SubType == productSubtype select item);
            List<Product> p = products.ToList();
            //Product p = (Product)product;
            Session["CurrentUrl"] = "/Products/Index?productType=" + productType + "&productSubtype=" + productSubtype;
            Session["NavigationLinkProductAddress"] = Session["CurrentUrl"];
            return View(p);
        }

        public ActionResult ProductDetails(int productID=0)
        {
            //read product from the database
            Product product = (from item in shoppingDb.products where item.ID == productID select item).SingleOrDefault();
            Session["CurrentUrl"] = "/Products/ProductDetails?productID=" + productID;
            //Session["ReturnProductsUrl"] = Request.Path.ToString();
            ViewBag.Comment = "this is test";
            return View(product);
        }
    }
}
