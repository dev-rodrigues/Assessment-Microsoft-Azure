namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .Index(t => t.CountryId)
                .Index(t => t.StateId);
            
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
            DropForeignKey("dbo.Friends", "StateId", "dbo.States");
            DropForeignKey("dbo.Friends", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.Friendships", new[] { "Follower_Id" });
            DropIndex("dbo.Friendships", new[] { "Followed_Id" });
            DropIndex("dbo.Friends", new[] { "StateId" });
            DropIndex("dbo.Friends", new[] { "CountryId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropTable("dbo.Friendships");
            DropTable("dbo.Friends");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
        }
    }
}
