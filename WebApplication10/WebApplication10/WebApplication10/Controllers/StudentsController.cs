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
    public class StudentsController : Controller
    {
        private SchoolRepository repository = new SchoolRepository(new SchoolContext());

        // GET: Students
        public ActionResult Index()
        {
            return View(repository.getStudents());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Students students = repository.getStudent(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }


        public ActionResult StudentsThatPassed()
        {
            ViewBag.FirstName= new SelectList(repository.getStudents(), "ID", "FirstName");

            return View();

        }

        [HttpGet]
        public PartialViewResult UpdateAjax(int id)
        {


            Students student = repository.getStudent(id); 

            return PartialView("Expand", repository.passedCourse(student));


        }


        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = repository.getStudent(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = repository.getStudent(id);
            repository.deleteStudent(students);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repository.dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
