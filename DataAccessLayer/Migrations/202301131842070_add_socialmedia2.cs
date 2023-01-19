namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_socialmedia2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialMedias", "Icon", c => c.String());
            AddColumn("dbo.SocialMedias", "Status", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SocialMedias", "Status");
            DropColumn("dbo.SocialMedias", "Icon");
        }
    }
}
