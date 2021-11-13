namespace InstituteOfComputers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCourseStatus1 : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT CourseStatus ON");
            Sql("INSERT INTO CourseStatus(Id,CourseStatusName)VALUES(3,'Not Available')");
        }
        
        public override void Down()
        {
        }
    }
}
