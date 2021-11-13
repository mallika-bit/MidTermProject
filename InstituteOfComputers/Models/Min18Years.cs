using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InstituteOfComputers.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var student = (Student)validationContext.ObjectInstance;

            
            if (student.DateOfBirth == null)
            {
                return new ValidationResult("Date of birth is required");
            }
            var age = DateTime.Today.Year - student.DateOfBirth.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Student must be greater than 18 years old");
        }
    }
}