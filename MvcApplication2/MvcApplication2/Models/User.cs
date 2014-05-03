using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcApplication2.Models
{
    public class User
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName {get;set;}
        public string email { get; set; }
        public string password { get; set; }
        public virtual ICollection<Cart> carts { get; set; }
    }

    public class ShoppingDbContext : DbContext
    {
        public DbSet<User> users { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<Cart> carts { get; set; }
    }
}