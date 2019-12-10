namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class url_img : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Friends", "URLImg", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Friends", "URLImg");
        }
    }
}
