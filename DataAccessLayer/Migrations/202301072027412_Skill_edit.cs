namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Skill_edit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Skills", "SkillValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "SkillValue", c => c.String());
        }
    }
}
