using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InstituteOfComputers.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [Display(Name =" Course Name")]
        public string  CourseName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Instructor")]
        public string TutorName { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(1,10)]
        public int CourseRating { get; set; }
    }
}