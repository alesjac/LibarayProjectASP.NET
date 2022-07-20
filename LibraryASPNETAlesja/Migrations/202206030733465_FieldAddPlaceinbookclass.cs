namespace LibraryASPNETAlesja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldAddPlaceinbookclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PlaceInShelf", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "PlaceInShelf");
        }
    }
}
