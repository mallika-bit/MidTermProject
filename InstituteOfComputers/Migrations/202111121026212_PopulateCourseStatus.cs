namespace InstituteOfComputers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCourseStatus : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT CourseStatus ON");
            Sql("INSERT INTO CourseStatus(Id,CourseStatusName)VALUES(1,'In Progress')");
            Sql("INSERT INTO CourseStatus(Id,CourseStatusName)VALUES(2,'In Completed')");
        }
        
        public override void Down()
        {
        }
    }
}
