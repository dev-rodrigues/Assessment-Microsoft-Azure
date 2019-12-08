namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atualizacao2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.States", new[] { "CountryId" });
            RenameColumn(table: "dbo.States", name: "CountryId", newName: "Country_Id");
            AlterColumn("dbo.States", "Country_Id", c => c.Int());
            CreateIndex("dbo.States", "Country_Id");
            AddForeignKey("dbo.States", "Country_Id", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.States", "Country_Id", "dbo.Countries");
            DropIndex("dbo.States", new[] { "Country_Id" });
            AlterColumn("dbo.States", "Country_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.States", name: "Country_Id", newName: "CountryId");
            CreateIndex("dbo.States", "CountryId");
            AddForeignKey("dbo.States", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
