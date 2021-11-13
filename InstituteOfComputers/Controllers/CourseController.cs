using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using InstituteOfComputers.Models;
using InstituteOfComputers.ViewModels;

namespace InstituteOfComputers.Controllers
{
    public class CourseController : Controller
    {
        private InstituteDbContext _context;
        public CourseController()
        {
            _context = new InstituteDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Course
        public ActionResult Index()
        {
            IOrderedEnumerable<Course> courses = _context.Courses.ToList().OrderByDescending(c=>c.Id);
           
            return View(courses);
        }
        public ActionResult NewCourse()
        {
            var courses = new Course();

            return View("NewCourse",courses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Course course)
        {
            if (!ModelState.IsValid)
            {
                var courses = new Course();

                return View("NewCourse", courses);
            }

            if (course.Id == 0)
            {
                _context.Courses.Add(course);
            }
            else {
                var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == course.Id);
                courseInDb.CourseName = course.CourseName;
                courseInDb.Description = course.Description;
                courseInDb.TutorName = course.TutorName;
                courseInDb.CourseRating = course.CourseRating;
                    }

            _context.SaveChanges();
            return RedirectToAction("Index","Course");
        }
        public ActionResult EditCourse(int id)

        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            var editCourse = new Course();
           editCourse = course;
            return View("NewCourse", editCourse);

        }

        public ActionResult DeleteCourse(int id)
        {
           var course =  _context.Courses.SingleOrDefault(c => c.Id == id);

            _context.Courses.Remove(course);

            _context.SaveChanges();

            return RedirectToAction("Index");
           
        }
    }
}