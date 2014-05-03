    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    namespace MvcApplication2.Models
    {
        public class Cart
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID {get; set;}
            //foreign key to the User table
            [ForeignKey("User")]
            public int userID {get; set;}

            //navigation property for the user
           public virtual User User {get; set;}

            [ForeignKey("Product")]
            public int productID {get; set;}

            //navigation property
            public virtual Product Product {get; set;}

            public int quantity {get; set;}

            public bool billed { get; set; }

            public float total { get { return quantity * Product.Price; } }
        }
    }