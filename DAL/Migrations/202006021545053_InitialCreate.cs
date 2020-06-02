namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Periodicals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Period = c.String(),
                        ImageName = c.String(),
                        NumberOfEdition = c.Int(nullable: false),
                        NumberOfPublications = c.Int(nullable: false),
                        Annotation = c.String(),
                        Topic_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id, cascadeDelete: true)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Periodicals", "Topic_Id", "dbo.Topics");
            DropIndex("dbo.Periodicals", new[] { "Topic_Id" });
            DropTable("dbo.Topics");
            DropTable("dbo.Periodicals");
        }
    }
}
