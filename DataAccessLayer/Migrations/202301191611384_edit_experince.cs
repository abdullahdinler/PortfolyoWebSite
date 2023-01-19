namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_experince : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Experiences", "WorkInfo", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Experiences", "WorkInfo", c => c.String(maxLength: 100));
        }
    }
}
