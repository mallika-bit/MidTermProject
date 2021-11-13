using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
using System.Web;

namespace InstituteOfComputers.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Grade { get; set; }


        
        public Course Course { get; set; }

        [Required]
        [Display(Name ="Course")]
        public int CourseId { get; set; }


        [Required]
        [Display(Name ="Date Of Birth")]
        [Column(TypeName = "DateTime2")]
        [Min18Years]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime EnrolledDate { get; set; }

        public CourseStatus CourseStatus { get; set; }

        [Required]
        public int? CourseStatusId { get; set; }

        public Student()
        {
            Grade = "Not Available";
            CourseStatusId = 3;

        }
    }
}