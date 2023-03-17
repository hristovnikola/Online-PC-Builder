namespace Proekt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImgURL = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Price = c.Int(nullable: false),
                        InStock = c.Boolean(nullable: false),
                        Category = c.Int(nullable: false),
                        Manufacturer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
