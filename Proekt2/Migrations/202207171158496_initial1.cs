namespace Proekt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomMades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
        
        public override void Down()
        {
            DropTable("dbo.CustomMades");
        }
    }
}
