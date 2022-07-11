namespace LibrariDenisKoleci.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "CatgoryID", c => c.Byte(nullable: false));
            AddColumn("dbo.Books", "Category_Id", c => c.Byte());
            CreateIndex("dbo.Books", "Category_Id");
            AddForeignKey("dbo.Books", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "Category_Id" });
            DropColumn("dbo.Books", "Category_Id");
            DropColumn("dbo.Books", "CatgoryID");
            DropTable("dbo.Categories");
        }
    }
}
