namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Friend_Id = c.Int(),
                        Seguido_Id = c.Int(),
                        Seguidor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Friends", t => t.Friend_Id)
                .ForeignKey("dbo.Friends", t => t.Seguido_Id)
                .ForeignKey("dbo.Friends", t => t.Seguidor_Id)
                .Index(t => t.Friend_Id)
                .Index(t => t.Seguido_Id)
                .Index(t => t.Seguidor_Id);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        CountryId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlPicture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlPicture = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: false)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connections", "Seguidor_Id", "dbo.Friends");
            DropForeignKey("dbo.Connections", "Seguido_Id", "dbo.Friends");
            DropForeignKey("dbo.Friends", "StateId", "dbo.States");
            DropForeignKey("dbo.Friends", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Connections", "Friend_Id", "dbo.Friends");
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.Friends", new[] { "StateId" });
            DropIndex("dbo.Friends", new[] { "CountryId" });
            DropIndex("dbo.Connections", new[] { "Seguidor_Id" });
            DropIndex("dbo.Connections", new[] { "Seguido_Id" });
            DropIndex("dbo.Connections", new[] { "Friend_Id" });
            DropTable("dbo.States");
            DropTable("dbo.Countries");
            DropTable("dbo.Friends");
            DropTable("dbo.Connections");
        }
    }
}
