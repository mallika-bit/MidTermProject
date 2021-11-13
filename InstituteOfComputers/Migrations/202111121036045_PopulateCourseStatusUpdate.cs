namespace InstituteOfComputers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCourseStatusUpdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE CourseStatus SET CourseStatusName='Completed' WHERE Id=2");
        }
        
        public override void Down()
        {
        }
    }
}
