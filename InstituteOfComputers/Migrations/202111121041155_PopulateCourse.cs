namespace InstituteOfComputers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCourse : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Courses ON");
            Sql("INSERT INTO Courses(Id,CourseName,Description,TutorName,CourseRating)" +
                "VALUES(1,'Java','Java is a programming language','Ajay',5)");

            Sql("INSERT INTO Courses(Id,CourseName,Description,TutorName,CourseRating)" +
               "VALUES(2,'Python','Python is a popular programming language','Anand',4)");
        }
        
        public override void Down()
        {
        }
    }
}
