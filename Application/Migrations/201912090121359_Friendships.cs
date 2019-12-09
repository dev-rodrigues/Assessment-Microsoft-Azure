namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Friendships : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Followed_Id = c.Int(),
                        Follower_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Friends", t => t.Followed_Id)
                .ForeignKey("dbo.Friends", t => t.Follower_Id)
                .Index(t => t.Followed_Id)
                .Index(t => t.Follower_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "Follower_Id", "dbo.Friends");
            DropForeignKey("dbo.Friendships", "Followed_Id", "dbo.Friends");
            DropIndex("dbo.Friendships", new[] { "Follower_Id" });
            DropIndex("dbo.Friendships", new[] { "Followed_Id" });
            DropTable("dbo.Friendships");
        }
    }
}
