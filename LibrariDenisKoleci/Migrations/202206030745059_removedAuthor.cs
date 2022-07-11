                                                                                                                                                                                                namespace LibrariDenisKoleci.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedAuthor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "Id", "dbo.Books");
            DropForeignKey("dbo.Categories", "Id", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "Id" });
            DropIndex("dbo.Categories", new[] { "Id" });
            DropPrimaryKey("dbo.Categories");
            AddColumn("dbo.Books", "Author", c => c.String());
            AddColumn("dbo.Books", "Category_Id", c => c.Int());
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
            CreateIndex("dbo.Books", "Category_Id");
            AddForeignKey("dbo.Books", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Categories", "BookId");
            DropTable("dbo.Authors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "BookId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Books", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "Category_Id" });
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Category_Id");
            DropColumn("dbo.Books", "Author");
            AddPrimaryKey("dbo.Categories", "Id");
            CreateIndex("dbo.Categories", "Id");
            CreateIndex("dbo.Authors", "Id");
            AddForeignKey("dbo.Categories", "Id", "dbo.Books", "Id");
            AddForeignKey("dbo.Authors", "Id", "dbo.Books", "Id");
        }
    }
}
