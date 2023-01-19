namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "MessageTxt", c => c.String(nullable: false));
            AlterColumn("dbo.Educations", "EpisodeName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Educations", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Experiences", "Position", c => c.String(maxLength: 100));
            AlterColumn("dbo.Experiences", "WorkInfo", c => c.String(maxLength: 100));
            AlterColumn("dbo.Skills", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Skills", "Txt", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "Txt", c => c.String());
            AlterColumn("dbo.Skills", "Name", c => c.String());
            AlterColumn("dbo.Experiences", "WorkInfo", c => c.String());
            AlterColumn("dbo.Experiences", "Position", c => c.String());
            AlterColumn("dbo.Educations", "City", c => c.String());
            AlterColumn("dbo.Educations", "EpisodeName", c => c.String());
            AlterColumn("dbo.Contacts", "MessageTxt", c => c.String());
            AlterColumn("dbo.Contacts", "Subject", c => c.String());
            AlterColumn("dbo.Contacts", "Mail", c => c.String());
        }
    }
}
