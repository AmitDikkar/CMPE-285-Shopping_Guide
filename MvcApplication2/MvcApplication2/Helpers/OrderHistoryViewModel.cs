using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Helpers
{
    public class OrderHistoryViewModel
    {
        public List<Cart> cartsList { get; set; }
 
        public List<Cart> ordersList {get; set;}
    }
}