namespace LibraryASPNETAlesja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removenumberinstock : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "NumberInStock", c => c.Int(nullable: false));
        }
    }
}
