namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "StateId", "dbo.States");
            DropIndex("dbo.Friends", new[] { "StateId" });
            AlterColumn("dbo.Friends", "StateId", c => c.Int());
            CreateIndex("dbo.Friends", "StateId");
            AddForeignKey("dbo.Friends", "StateId", "dbo.States", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "StateId", "dbo.States");
            DropIndex("dbo.Friends", new[] { "StateId" });
            AlterColumn("dbo.Friends", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Friends", "StateId");
            AddForeignKey("dbo.Friends", "StateId", "dbo.States", "Id", cascadeDelete: true);
        }
    }
}
