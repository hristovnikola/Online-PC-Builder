namespace Proekt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Products", "ShoppingCart_Id");
            AddForeignKey("dbo.Products", "ShoppingCart_Id", "dbo.ShoppingCarts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropIndex("dbo.Products", new[] { "ShoppingCart_Id" });
            DropColumn("dbo.Products", "ShoppingCart_Id");
            DropTable("dbo.ShoppingCarts");
        }
    }
}
