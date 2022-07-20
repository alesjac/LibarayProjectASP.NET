namespace LibraryASPNETAlesja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteclassestoaddagainlater : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CatgoryID", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CatgoryID" });
            DropTable("dbo.Books");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        CatgoryID = c.Byte(nullable: false),
                        PlaceInShelf = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Books", "CatgoryID");
            AddForeignKey("dbo.Books", "CatgoryID", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
