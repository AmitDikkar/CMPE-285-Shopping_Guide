namespace MvcApplication2.Migrations
{
    using MvcApplication2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcApplication2.Models.ShoppingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcApplication2.Models.ShoppingDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.users.AddOrUpdate(i => i.email,

                new User
                {
                    email = "amit.dikkar@gmail.com",
                    firstName = "Amit",
                    lastName = "Dikkar",
                    password = "password"
                },
                new User
                {
                    email = "pravin@gmail.com",
                    firstName = "Pravin",
                    lastName = "Agarwal",
                    password = "password"
                }
                );

            context.products.AddOrUpdate(i => i.ProductName,

                new Product
                {
                    ProductName = "RedShoe",
                    ProductShortDescription = "Excellent Red Shoe",
                    Price = (float) 150.00,
                    Type = "Clothes",
                    SubType = "WomenClothes",
                    ListImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Red_shoe.jpg",
                    LargeImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Large/Red_shoe.jpg"
                },
                new Product
                {
                    ProductName = "BlackShoe",
                    ProductShortDescription = "Excellent Black Shoe",
                    Price = (float)150.00,
                    Type = "Clothes",
                    SubType = "WomenClothes",
                    ListImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Black_shoe.jpg",
                    LargeImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Large/Black_shoe.jpg"
                },
                new Product
                {
                    ProductName="Blue Shoe",
                    ProductShortDescription = "Excellent Blue Shoe",
                    Price = (float)199.00,
                    Type = "Clothes",
                    SubType = "WomenClothes",
                    ListImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Blue_shoe.jpg",
                    LargeImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Large/Blue_shoe.jpg"
                }
                );

            context.carts.AddOrUpdate(i => i.ID,
                new Cart
                {
                    productID = 1,
                    userID = 1,
                    billed = false,
                    quantity = 1
                },
                new Cart
                {
                    productID = 2,
                    userID = 2,
                    billed = true,
                    quantity = 1
                }
                );
        }
    }
}
