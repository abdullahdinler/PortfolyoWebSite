namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_contact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Status");
        }
    }
}
