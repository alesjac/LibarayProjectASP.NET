namespace LibraryASPNETAlesja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedateofreturn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rents", "DateReturned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "DateReturned", c => c.DateTime());
        }
    }
}
