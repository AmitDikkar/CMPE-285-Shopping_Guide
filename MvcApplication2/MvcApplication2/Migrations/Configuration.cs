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
                //Clother-WomensClothes
                new Product
                {
                    ProductName = "RedShoe",
                    ProductShortDescription = "Excellent Red Shoe, Like it?",
                    Price = (float) 150.00,
                    Type = "Clothes",
                    SubType = "WomenClothes",
                    ListImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Red_shoe.jpg",
                    LargeImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Large/Red_shoe.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Focus/Red_shoe.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Focus/Red_shoe.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Focus/Red_shoe.jpg",
                },
                new Product
                {
                    ProductName = "BlackShoe",
                    ProductShortDescription = "Excellent Black Shoe",
                    Price = (float)150.00,
                    Type = "Clothes",
                    SubType = "WomenClothes",
                    ListImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Black_shoe.jpg",
                    LargeImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Large/Black_shoe.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Focus/Red_shoe.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Focus/Red_shoe.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Focus/Red_shoe.jpg",
                },
                new Product
                {
                    ProductName="Blue Shoe",
                    ProductShortDescription = "Perfect Match for you",
                    Price = (float)199.00,
                    Type = "Clothes",
                    SubType = "WomenClothes",
                    ListImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Blue_shoe.jpg",
                    LargeImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Large/Blue_shoe.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Focus/Red_shoe.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Focus/Red_shoe.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/Clothes/WomensClothes/Focus/Red_shoe.jpg",
                },
                //Electronics Camera
                new Product
                {
                    ProductName = "Canon - EOS Rebel T3i",
                    ProductShortDescription = "Canon EOS Rebel T3i DSLR 18–135mm",
                    Price = (float)599.99,
                    Type = "electronics",
                    SubType = "camera",
                    ListImageUrl = "/Content/themes/images/products/electronics/camera/Canon_Camera_Black.jpg",
                    LargeImageUrl = "/Content/themes/images/products/electronics/camera/Large/Canon_Camera_Black.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Canon_Camera_Black_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Canon_Camera_Black_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Canon_Camera_Black_f3.jpg",
                },
                new Product
                {
                    ProductName = "Fujifilm - X100S",
                    ProductShortDescription = "APS-C X-Trans CMOS II, filter array",
                    Price = (float)1299.99,
                    Type = "electronics",
                    SubType = "camera",
                    ListImageUrl = "/Content/themes/images/products/electronics/camera/Fujifilm_Camera_Black.jpg",
                    LargeImageUrl = "/Content/themes/images/products/electronics/camera/Large/Fujifilm_Camera_Black.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Fujifilm_Camera_Black_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Fujifilm_Camera_Black_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Fujifilm_Camera_Black_f3.jpg",
                },
                new Product
                {
                    ProductName = "Kodak - EasyShare",
                    ProductShortDescription = "M522 - the hot little camera from Kodak.",
                    Price = (float)227.99,
                    Type = "electronics",
                    SubType = "camera",
                    ListImageUrl = "/Content/themes/images/products/electronics/camera/Kodak_Camera_Red.jpg",
                    LargeImageUrl = "/Content/themes/images/products/electronics/camera/Large/Kodak_Camera_Red.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Kodak_Camera_Red_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Kodak_Camera_Red_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Kodak_Camera_Red_f3.jpg",
                },
                new Product
                {
                    ProductName = "Panasonic - LUMIX FZ200",
                    ProductShortDescription = " MOS image sensor with LSI Engine",
                    Price = (float)447.89,
                    Type = "electronics",
                    SubType = "camera",
                    ListImageUrl = "/Content/themes/images/products/electronics/camera/Lumix_Camera_Black.jpg",
                    LargeImageUrl = "/Content/themes/images/products/electronics/camera/Large/Lumix_Camera_Black.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Lumix_Camera_Black_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Lumix_Camera_Black_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Lumix_Camera_Black_f3.jpg",
                },
                new Product
                {
                    ProductName = "Nikon - D7000",
                    ProductShortDescription = "ISO range for low-light shooting",
                    Price = (float)847.89,
                    Type = "electronics",
                    SubType = "camera",
                    ListImageUrl = "/Content/themes/images/products/electronics/camera/Nikon_Camera_Black.jpg",
                    LargeImageUrl = "/Content/themes/images/products/electronics/camera/Large/Nikon_Camera_Black.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Nikon_Camera_Black_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Nikon_Camera_Black_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Nikon_Camera_Black_f3.jpg",
                },
                new Product
                {
                    ProductName = "Sony - Cyber-shot",
                    ProductShortDescription = " 16.2-megapixel Exmor R CMOS sensor",
                    Price = (float)229.89,
                    Type = "electronics",
                    SubType = "camera",
                    ListImageUrl = "/Content/themes/images/products/electronics/camera/Sony_Camera_Silver.jpg",
                    LargeImageUrl = "/Content/themes/images/products/electronics/camera/Large/Sony_Camera_Silver.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Sony_Camera_Silver_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Sony_Camera_Silver_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Sony_Camera_Silver_f3.jpg",
                },
                new Product
                {
                    ProductName = "Sony - Cyber-shot",
                    ProductShortDescription = " 16.2-megapixel Exmor R CMOS sensor",
                    Price = (float)229.89,
                    Type = "electronics",
                    SubType = "camera",
                    ListImageUrl = "/Content/themes/images/products/electronics/camera/Sony_Camera_Silver.jpg",
                    LargeImageUrl = "/Content/themes/images/products/electronics/camera/Large/Sony_Camera_Silver.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Sony_Camera_Silver_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Sony_Camera_Silver_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/electronics/camera/Focus/Sony_Camera_Silver_f3.jpg",
                },

                //Health and beauty-health 
                new Product
                {
                    ProductName = "Nike+ FuelBand",
                    ProductShortDescription = "LIFE IS A SPORT. MAKE IT COUNT.",
                    Price = (float)236.39,
                    Type = "healthandbeauty",
                    SubType = "healthequipments",
                    ListImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Nike_Fuel.jpg",
                    LargeImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Large/Nike_Fuel.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Nike_Fuel_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Nike_Fuel_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Nike_Fuel_f3.jpg",
                },
                new Product
                {
                    ProductName = "Philips Sonicare",
                    ProductShortDescription = "Rechargeable Toothbrush & 5 Modes",
                    Price = (float)49.99,
                    Type = "healthandbeauty",
                    SubType = "healthequipments",
                    ListImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Philips_Tooth.jpg",
                    LargeImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Large/Philips_Tooth.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Philips_Tooth_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Philips_Tooth_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Philips_Tooth_f3.jpg",
                },
                new Product
                {
                    ProductName = "Gillette Fusion Razor",
                    ProductShortDescription = "Reduce pressure, More comfort.",
                    Price = (float)39.99,
                    Type = "healthandbeauty",
                    SubType = "healthequipments",
                    ListImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Razor.jpg",
                    LargeImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Large/Razor.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Razor_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Razor_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Razor_f3.jpg",
                },
                new Product
                {
                    ProductName = "Samsung - Gear Fit",
                    ProductShortDescription = "Sync Results With Samsung Phone or Tablet.",
                    Price = (float)199.99,
                    Type = "healthandbeauty",
                    SubType = "healthequipments",
                    ListImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Samsung_Gear.jpg",
                    LargeImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Large/Samsung_Gear.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Samsung_Gear_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Samsung_Gear_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Samsung_Gear_f3.jpg",
                },
                new Product
                {
                    ProductName = "Pro-Form 2500 Treadmill",
                    ProductShortDescription = "Easy connection of an Apple® iPod®",
                    Price = (float)199.99,
                    Type = "healthandbeauty",
                    SubType = "healthequipments",
                    ListImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Treadmill.jpg",
                    LargeImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Large/Treadmill.jpg",
                    Focus1ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Treadmill_f1.jpg",
                    Focus2ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Treadmill_f2.jpg",
                    Focus3ImageUrl = "/Content/themes/images/products/healthandbeauty/healthequipments/Focus/Treadmill_f3.jpg",
                });
            /*
            context.carts.AddOrUpdate(i => i.ID,
                new Cart
                {
                    productID = 1,
                    userID = 1,
                    billed = false,
                    quantity = 2
                },
                new Cart
                {
                    productID = 2,
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
                });*/
        }
    }
}
