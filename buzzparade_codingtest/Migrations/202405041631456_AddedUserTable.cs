namespace buzzparade_codingtest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Surveys", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Surveys", "UserId");
            AddForeignKey("dbo.Surveys", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "UserId", "dbo.Users");
            DropIndex("dbo.Surveys", new[] { "UserId" });
            DropColumn("dbo.Surveys", "UserId");
            DropTable("dbo.Users");
        }
    }
}
