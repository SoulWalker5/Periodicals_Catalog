namespace Periodicals_Catalog_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPageSize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PageSetup_PageNumber", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "PageSetup_PageSize", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "PageSetup_TotalItems", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PageSetup_TotalItems");
            DropColumn("dbo.AspNetUsers", "PageSetup_PageSize");
            DropColumn("dbo.AspNetUsers", "PageSetup_PageNumber");
        }
    }
}
