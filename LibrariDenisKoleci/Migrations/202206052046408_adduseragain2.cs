namespace LibrariDenisKoleci.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduseragain2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        UserRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleID, cascadeDelete: true)
                .Index(t => t.UserRoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRoleID", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRoleID" });
            DropTable("dbo.Users");
        }
    }
}
