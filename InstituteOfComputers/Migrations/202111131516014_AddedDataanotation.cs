namespace InstituteOfComputers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataanotation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "CourseStatusId", "dbo.CourseStatus");
            DropIndex("dbo.Students", new[] { "CourseStatusId" });
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Grade", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "CourseStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "CourseStatusId");
            AddForeignKey("dbo.Students", "CourseStatusId", "dbo.CourseStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CourseStatusId", "dbo.CourseStatus");
            DropIndex("dbo.Students", new[] { "CourseStatusId" });
            AlterColumn("dbo.Students", "CourseStatusId", c => c.Int());
            AlterColumn("dbo.Students", "Grade", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            CreateIndex("dbo.Students", "CourseStatusId");
            AddForeignKey("dbo.Students", "CourseStatusId", "dbo.CourseStatus", "Id");
        }
    }
}
