namespace LibrariDenisKoleci.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2fieldsinbooknumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "NumberAvaiable", c => c.Int(nullable: false));
            AlterColumn("dbo.BookLoans", "DateReturned", c => c.DateTime());

            Sql("Update Book SET NumberAvaiable = NumberInStock");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookLoans", "DateReturned", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "NumberAvaiable");
            DropColumn("dbo.Books", "NumberInStock");
        }
    }
}
