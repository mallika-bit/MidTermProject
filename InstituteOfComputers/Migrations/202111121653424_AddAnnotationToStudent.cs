namespace InstituteOfComputers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToStudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "CourseStatusId", "dbo.CourseStatus");
            DropIndex("dbo.Students", new[] { "CourseStatusId" });
            AlterColumn("dbo.Students", "CourseStatusId", c => c.Int());
            CreateIndex("dbo.Students", "CourseStatusId");
            AddForeignKey("dbo.Students", "CourseStatusId", "dbo.CourseStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CourseStatusId", "dbo.CourseStatus");
            DropIndex("dbo.Students", new[] { "CourseStatusId" });
            AlterColumn("dbo.Students", "CourseStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "CourseStatusId");
            AddForeignKey("dbo.Students", "CourseStatusId", "dbo.CourseStatus", "Id", cascadeDelete: true);
        }
    }
}
