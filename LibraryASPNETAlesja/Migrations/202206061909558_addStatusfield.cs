namespace LibraryASPNETAlesja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStatusfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "Status");
        }
    }
}
