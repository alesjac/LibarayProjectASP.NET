namespace LibrariDenisKoleci.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datereturnfieldadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookLoans", "DateReturned", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookLoans", "DateReturned");
        }
    }
}
