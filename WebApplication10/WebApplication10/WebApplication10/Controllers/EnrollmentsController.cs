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
    public class EnrollmentsController : Controller
    {
        private SchoolRepository repository = new SchoolRepository(new SchoolContext());


        public ActionResult Index()
        {


            var enrollments = repository.getEnrollments();
            return View(enrollments.ToList());
        }

 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Enrollment enrollment = repository.getEnrollment(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

 
        public ActionResult Create()
        {
            
            ViewBag.CourseID = new SelectList(repository.getCourses(), "ID", "Title");
            ViewBag.StudentID = new SelectList(repository.getStudents(), "ID", "FirstName");
            return View();
        }

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentID,StudentID,CourseID,date,Grade")] Enrollment enrollment)
        {
            if (Validate(enrollment))
            {
                if (ModelState.IsValid)
                {
                    repository.addEnrollment(enrollment);
                    return RedirectToAction("Index");
                }
            }


            ViewBag.ERRORMSG = "Prijavili ste vise od 5 puta isti ispit ove godine!!!";
            ViewBag.CourseID = new SelectList(repository.getCourses(), "ID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(repository.getStudents(), "ID", "FirstName", enrollment.StudentID);
            return View(enrollment);
        }

        private bool Validate(Enrollment enrollment)
        {
            return repository.checkIfStudenCanEnroll(enrollment.StudentID, enrollment.CourseID, enrollment.date.Year);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment =repository.getEnrollment(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(repository.getCourses(), "ID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(repository.getStudents(), "ID", "FirstName", enrollment.StudentID);
            return View(enrollment);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentID,StudentID,CourseID,date,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                repository.editEnrollment(enrollment);
                
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(repository.getCourses(), "ID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(repository.getStudents(), "ID", "FirstName", enrollment.StudentID);
            return View(enrollment);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = repository.getEnrollment(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = repository.getEnrollment(id);
            repository.deleteEnrollment(enrollment);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repository.dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
