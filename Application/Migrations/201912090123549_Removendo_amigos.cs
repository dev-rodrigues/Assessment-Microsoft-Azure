namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removendo_amigos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "Friend_Id", "dbo.Friends");
            DropIndex("dbo.Friends", new[] { "Friend_Id" });
            DropColumn("dbo.Friends", "Friend_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Friends", "Friend_Id", c => c.Int());
            CreateIndex("dbo.Friends", "Friend_Id");
            AddForeignKey("dbo.Friends", "Friend_Id", "dbo.Friends", "Id");
        }
    }
}
