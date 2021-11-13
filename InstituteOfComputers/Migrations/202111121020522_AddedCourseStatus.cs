namespace InstituteOfComputers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourseStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseStatusName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "CourseStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "CourseStatusId");
            AddForeignKey("dbo.Students", "CourseStatusId", "dbo.CourseStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CourseStatusId", "dbo.CourseStatus");
            DropIndex("dbo.Students", new[] { "CourseStatusId" });
            DropColumn("dbo.Students", "CourseStatusId");
            DropTable("dbo.CourseStatus");
        }
    }
}
