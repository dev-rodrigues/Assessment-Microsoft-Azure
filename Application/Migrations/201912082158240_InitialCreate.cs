namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
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
                        Friend_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: false)
                .ForeignKey("dbo.Friends", t => t.Friend_Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .Index(t => t.CountryId)
                .Index(t => t.StateId)
                .Index(t => t.Friend_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "StateId", "dbo.States");
            DropForeignKey("dbo.Friends", "Friend_Id", "dbo.Friends");
            DropForeignKey("dbo.Friends", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.Friends", new[] { "Friend_Id" });
            DropIndex("dbo.Friends", new[] { "StateId" });
            DropIndex("dbo.Friends", new[] { "CountryId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropTable("dbo.Friends");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
        }
    }
}
