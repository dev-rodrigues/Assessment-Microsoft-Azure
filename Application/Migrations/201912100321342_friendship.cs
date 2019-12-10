namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class friendship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Friendships", "Friend_Id", c => c.Int());
            CreateIndex("dbo.Friendships", "Friend_Id");
            AddForeignKey("dbo.Friendships", "Friend_Id", "dbo.Friends", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "Friend_Id", "dbo.Friends");
            DropIndex("dbo.Friendships", new[] { "Friend_Id" });
            DropColumn("dbo.Friendships", "Friend_Id");
        }
    }
}
