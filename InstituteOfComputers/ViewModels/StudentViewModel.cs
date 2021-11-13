using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InstituteOfComputers.Models;


namespace InstituteOfComputers.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<CourseStatus> CourseStatuses { get; set; }
    }
}