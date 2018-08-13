namespace PassWeb.Inf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTokenClass_NamespaceCorrection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PassResetTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(nullable: false),
                        GeneratedDateTime = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PassResetTokens", "User_Id", "dbo.Users");
            DropIndex("dbo.PassResetTokens", new[] { "User_Id" });
            DropTable("dbo.PassResetTokens");
        }
    }
}
