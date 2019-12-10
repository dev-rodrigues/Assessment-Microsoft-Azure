namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "CountryId", "dbo.Countries");
            DropIndex("dbo.Friends", new[] { "CountryId" });
            AlterColumn("dbo.Friends", "CountryId", c => c.Int());
            CreateIndex("dbo.Friends", "CountryId");
            AddForeignKey("dbo.Friends", "CountryId", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "CountryId", "dbo.Countries");
            DropIndex("dbo.Friends", new[] { "CountryId" });
            AlterColumn("dbo.Friends", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Friends", "CountryId");
            AddForeignKey("dbo.Friends", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
