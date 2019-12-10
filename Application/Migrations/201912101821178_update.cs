namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.States", new[] { "CountryId" });
            AlterColumn("dbo.States", "CountryId", c => c.Int());
            CreateIndex("dbo.States", "CountryId");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.States", new[] { "CountryId" });
            AlterColumn("dbo.States", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.States", "CountryId");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
