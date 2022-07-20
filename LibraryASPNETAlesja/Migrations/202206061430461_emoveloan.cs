namespace LibraryASPNETAlesja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emoveloan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookLoans", "BookID", "dbo.Books");
            DropForeignKey("dbo.BookLoans", "ReaderID", "dbo.Readers");
            DropForeignKey("dbo.BookLoans", "StatusID", "dbo.Status");
            DropIndex("dbo.BookLoans", new[] { "BookID" });
            DropIndex("dbo.BookLoans", new[] { "ReaderID" });
            DropIndex("dbo.BookLoans", new[] { "StatusID" });
            DropTable("dbo.BookLoans");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookLoans",
                c => new
                    {
                        BookID = c.Int(nullable: false),
                        ReaderID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        DateOfLoan = c.DateTime(nullable: false),
                        DateOfDeadlineForReturnBook = c.DateTime(nullable: false),
                        maxMonthsToReturnBook = c.Int(nullable: false),
                        DateReturned = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.BookID, t.ReaderID });
            
            CreateIndex("dbo.BookLoans", "StatusID");
            CreateIndex("dbo.BookLoans", "ReaderID");
            CreateIndex("dbo.BookLoans", "BookID");
            AddForeignKey("dbo.BookLoans", "StatusID", "dbo.Status", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookLoans", "ReaderID", "dbo.Readers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookLoans", "BookID", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
