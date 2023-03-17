namespace Proekt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropIndex("dbo.Products", new[] { "ShoppingCart_Id" });
            CreateTable(
                "dbo.PurchasedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        ImgURL = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Products", "ShoppingCart_Id");
            DropTable("dbo.ShoppingCarts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "ShoppingCart_Id", c => c.Int());
            DropTable("dbo.PurchasedProducts");
            CreateIndex("dbo.Products", "ShoppingCart_Id");
            AddForeignKey("dbo.Products", "ShoppingCart_Id", "dbo.ShoppingCarts", "Id");
        }
    }
}
