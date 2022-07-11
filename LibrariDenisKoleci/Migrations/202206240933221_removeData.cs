namespace LibrariDenisKoleci.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rents", "DateOfRent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "DateOfRent", c => c.DateTime(nullable: false));
        }
    }
}
