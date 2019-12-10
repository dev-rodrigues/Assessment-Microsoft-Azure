namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seila : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Friends", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Friends", "StateId", "dbo.States");
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.Friends", new[] { "CountryId" });
            DropIndex("dbo.Friends", new[] { "StateId" });
            AlterColumn("dbo.States", "CountryId", c => c.Int(nullable: true));
            AlterColumn("dbo.Friends", "CountryId", c => c.Int(nullable: true));
            AlterColumn("dbo.Friends", "StateId", c => c.Int(nullable: true));
            CreateIndex("dbo.States", "CountryId");
            CreateIndex("dbo.Friends", "CountryId");
            CreateIndex("dbo.Friends", "StateId");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Friends", "CountryId", "dbo.Countries", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Friends", "StateId", "dbo.States", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "StateId", "dbo.States");
            DropForeignKey("dbo.Friends", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.Friends", new[] { "StateId" });
            DropIndex("dbo.Friends", new[] { "CountryId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            AlterColumn("dbo.Friends", "StateId", c => c.Int());
            AlterColumn("dbo.Friends", "CountryId", c => c.Int());
            AlterColumn("dbo.States", "CountryId", c => c.Int());
            CreateIndex("dbo.Friends", "StateId");
            CreateIndex("dbo.Friends", "CountryId");
            CreateIndex("dbo.States", "CountryId");
            AddForeignKey("dbo.Friends", "StateId", "dbo.States", "Id");
            AddForeignKey("dbo.Friends", "CountryId", "dbo.Countries", "Id");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "Id");
        }
    }
}
