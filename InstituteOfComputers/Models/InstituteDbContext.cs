using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InstituteOfComputers.Models
{
    public class InstituteDbContext :DbContext
    {
        public InstituteDbContext(): base("name=InstituteDbContext")
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseStatus> CourseStatuses { get; set; }
    }
}