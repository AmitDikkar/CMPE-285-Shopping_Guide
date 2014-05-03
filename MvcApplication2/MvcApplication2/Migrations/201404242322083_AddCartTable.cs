namespace MvcApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userID = c.Int(nullable: false),
                        productID = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        billed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.userID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.productID, cascadeDelete: true)
                .Index(t => t.userID)
                .Index(t => t.productID);
            
            AlterColumn("dbo.Products", "Price", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropIndex("dbo.Carts", new[] { "productID" });
            DropIndex("dbo.Carts", new[] { "userID" });
            DropForeignKey("dbo.Carts", "productID", "dbo.Products");
            DropForeignKey("dbo.Carts", "userID", "dbo.Users");
            AlterColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            DropTable("dbo.Carts");
        }
    }
}
