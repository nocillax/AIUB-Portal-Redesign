namespace AIUB_Portal_Redesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProg2Dep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentProfiles", "Department", c => c.String(nullable: false));
            DropColumn("dbo.StudentProfiles", "Program");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentProfiles", "Program", c => c.String(nullable: false));
            DropColumn("dbo.StudentProfiles", "Department");
        }
    }
}
