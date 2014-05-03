namespace MvcApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDetailedDescription = c.String(),
                        ProductShortDescription = c.String(),
                        Type = c.String(),
                        SubType = c.String(),
                        Price = c.Double(nullable: false),
                        ListImageUrl = c.String(),
                        LargeImageUrl = c.String(),
                        Focus1ImageUrl = c.String(),
                        Focus2ImageUrl = c.String(),
                        Focus3ImageUrl = c.String(),
                        ModelNumber = c.String(),
                        Brand = c.String(),
                        Dimensions = c.String(),
                        color1 = c.String(),
                        color2 = c.String(),
                        FeatureInShort = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Users");
        }
    }
}
