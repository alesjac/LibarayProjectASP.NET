namespace LibrariDenisKoleci.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        ReaderID = c.Int(nullable: false),
                        DateOfRent = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.ReaderID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.ReaderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "ReaderID", "dbo.Readers");
            DropForeignKey("dbo.Rents", "BookID", "dbo.Books");
            DropIndex("dbo.Rents", new[] { "ReaderID" });
            DropIndex("dbo.Rents", new[] { "BookID" });
            DropTable("dbo.Rents");
        }
    }
}
