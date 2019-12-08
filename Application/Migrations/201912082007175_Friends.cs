namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Friends : DbMigration
    {
        public override void Up()
        {
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
                        Friend_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Friends", t => t.Friend_Id)
                .Index(t => t.Friend_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "Friend_Id", "dbo.Friends");
            DropIndex("dbo.Friends", new[] { "Friend_Id" });
            DropTable("dbo.Friends");
        }
    }
}
