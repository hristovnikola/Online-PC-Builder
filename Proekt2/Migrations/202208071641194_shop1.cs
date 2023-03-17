namespace Proekt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shop1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchasedProducts", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchasedProducts", "UserId", c => c.Int(nullable: false));
        }
    }
}
