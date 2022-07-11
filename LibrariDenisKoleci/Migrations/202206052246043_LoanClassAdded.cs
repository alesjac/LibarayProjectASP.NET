namespace LibrariDenisKoleci.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoanClassAdded : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => new { t.BookID, t.ReaderID })
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Readers", t => t.ReaderID, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.ReaderID)
                .Index(t => t.StatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookLoans", "StatusID", "dbo.Status");
            DropForeignKey("dbo.BookLoans", "ReaderID", "dbo.Readers");
            DropForeignKey("dbo.BookLoans", "BookID", "dbo.Books");
            DropIndex("dbo.BookLoans", new[] { "StatusID" });
            DropIndex("dbo.BookLoans", new[] { "ReaderID" });
            DropIndex("dbo.BookLoans", new[] { "BookID" });
            DropTable("dbo.BookLoans");
        }
    }
}
