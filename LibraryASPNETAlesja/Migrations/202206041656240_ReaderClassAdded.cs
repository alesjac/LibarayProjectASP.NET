namespace LibraryASPNETAlesja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReaderClassAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Readers");
        }
    }
}
