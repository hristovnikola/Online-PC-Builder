namespace Proekt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomMades", "ImgURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomMades", "ImgURL");
        }
    }
}
