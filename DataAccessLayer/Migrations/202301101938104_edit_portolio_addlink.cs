namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_portolio_addlink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Portfolios", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Portfolios", "Link");
        }
    }
}
