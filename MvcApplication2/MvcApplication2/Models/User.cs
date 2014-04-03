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
        public string email { get; set; }
        public string password { get; set; }
    }

    public class UserDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
    }
}