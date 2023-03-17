namespace Proekt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CustomMades");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomMades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImgURL = c.String(),
                        Price = c.Int(nullable: false),
                        Processor = c.String(),
                        MotherBoard = c.String(),
                        Storage = c.String(),
                        PowerSupply = c.String(),
                        RAM = c.String(),
                        GraphicsCard = c.String(),
                        Case = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
