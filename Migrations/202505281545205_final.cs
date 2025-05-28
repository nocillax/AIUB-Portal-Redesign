namespace AIUB_Portal_Redesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentProfiles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        StudentId = c.String(nullable: false, maxLength: 15),
                        Program = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentProfiles", "UserId", "dbo.Users");
            DropIndex("dbo.StudentProfiles", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.StudentProfiles");
        }
    }
}
