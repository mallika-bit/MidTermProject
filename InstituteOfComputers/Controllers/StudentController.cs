using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InstituteOfComputers.Models;
using InstituteOfComputers.ViewModels;


namespace InstituteOfComputers.Controllers
{
    public class StudentController : Controller
    {
        private InstituteDbContext _context;
        public StudentController()
        {
            _context = new InstituteDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Student
        public ActionResult Index()
        {
            IOrderedEnumerable<Student> students = _context.Students.Include(c => c.Course).Include(c=>c.CourseStatus).ToList().OrderByDescending(c=>c.Id);
            return View(students);
        }

        public ActionResult NewStudent()
        {
            var Courses = _context.Courses.ToList();
            var CourseStatuses = _context.CourseStatuses.ToList();

            var viewmodel = new StudentViewModel
            {
                Student = new Student(),
                Courses = Courses,
                CourseStatuses = CourseStatuses

            };
            return View("NewStudent", viewmodel);
            

        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new StudentViewModel()
                {
                    Student = student,
                    Courses = _context.Courses.ToList()
                };
                return View("NewStudent", viewmodel);
            }
            if(student.Id == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                var studentInDb = _context.Students.SingleOrDefault(c => c.Id == student.Id);

                studentInDb.FirstName = student.FirstName;
                studentInDb.LastName = student.LastName;
                studentInDb.DateOfBirth = student.DateOfBirth;
                studentInDb.EnrolledDate = student.EnrolledDate;
                studentInDb.CourseId = student.CourseId;
                studentInDb.CourseStatusId = student.CourseStatusId;
                studentInDb.Grade = student.Grade;
            }
            

            _context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault( c => c.Id == id);
           

            if(student == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new StudentViewModel
            {
                Student = student,
                Courses = _context.Courses.ToList(),
                CourseStatuses = _context.CourseStatuses
                
            };
            return View("EditStudent",viewmodel);
        }

        public ActionResult StudentDetails(int id)
        {
            var student = _context.Students.SingleOrDefault(c=>c.Id == id);

            var viewmodel = new StudentViewModel
            {
                Student = student,
                Courses = _context.Courses.ToList(),
                CourseStatuses = _context.CourseStatuses.ToList()
            };

            return View("StudentDetails",student);
        }

        public ActionResult Delete(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);

            _context.Students.Remove(student);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}