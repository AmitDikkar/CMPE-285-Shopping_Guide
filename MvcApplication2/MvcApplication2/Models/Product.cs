using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string ProductName { get; set; }

        public string ProductDetailedDescription { get; set; }

        public string ProductShortDescription { get; set; }

        public string Type { get; set; }

        public string SubType { get; set; }

        public float Price { get; set; }

        public string ListImageUrl { get; set; }

        public string LargeImageUrl { get; set; }

        public string Focus1ImageUrl { get; set; }

        public string Focus2ImageUrl { get; set; }

        public string Focus3ImageUrl { get; set; }

        public string ModelNumber { get; set; }

        //public DateTime ReleasedOn { get; set; }

        public string Brand { get; set; }

        public string Dimensions { get; set; }

        public string color1 { get; set; }

        public string color2 { get; set; }

        public string FeatureInShort { get; set; }

        public virtual ICollection<Cart> carts { get; set; }

    }

   /* public class ProductDbContext : DbContext
    {
        public DbSet<Product> products { get; set; }
    }*/
}