namespace LibrariDenisKoleci.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBookClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        CatgoryID = c.Int(nullable: false),
                        PlaceInShelf = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CatgoryID, cascadeDelete: true)
                .Index(t => t.CatgoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CatgoryID", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CatgoryID" });
            DropTable("dbo.Books");
        }
    }
}
