namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Education_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educations", "Explanation", c => c.String(maxLength: 150));
            DropColumn("dbo.Educations", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Educations", "City", c => c.String(maxLength: 50));
            DropColumn("dbo.Educations", "Explanation");
        }
    }
}
