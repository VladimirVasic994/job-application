using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Context;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class InstructorsController : Controller
    {
        private SchoolRepository repository = new SchoolRepository(new SchoolContext());


        // GET: Instructors
        public ActionResult Index()
        {
            repository.getInstructors();
            var instructors = repository.getInstructors();
            return View(instructors);
        }

        // GET: Instructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Instructor instructor = repository.getInstructor(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        public ActionResult Filter()
        {
            ViewBag.Instructors = new SelectList(repository.getInstructors(),"ID", "LastName");
            ViewBag.StartDate = new DateTime();
            ViewBag.EndDate = new DateTime();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Filter(Instructor instructor, DateTime StartDate,DateTime EndDate)
        {

           
            var coursesForInstructor = repository.getCoursesForInstructors(instructor.ID);
            
            var studentsThatPassed = repository.getStudentsThatPassed(coursesForInstructor, StartDate, EndDate);


            return PartialView("ListOfStudents", studentsThatPassed);
        }
        protected override void Dispose(bool disposing)
        {
            repository.dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
