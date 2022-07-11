namespace LibrariDenisKoleci.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reremovecategorytoadditagain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "Category_Id" });
            DropColumn("dbo.Books", "Category_Id");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "Category_Id", c => c.Int());
            CreateIndex("dbo.Books", "Category_Id");
            AddForeignKey("dbo.Books", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
