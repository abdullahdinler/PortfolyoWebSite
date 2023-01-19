namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_service_img : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Img", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Img");
        }
    }
}
