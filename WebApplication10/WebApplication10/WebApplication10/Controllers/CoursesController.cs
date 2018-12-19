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
    public class CoursesController : Controller
    {
        private SchoolRepository repository = new SchoolRepository(new SchoolContext());


        public ActionResult Index()
        {
            
            return View(repository.getCourses());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Course course = repository.getCourse(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }


        public ActionResult Create()
        {

            ViewBag.Instructors = new SelectList(repository.getInstructors(), "ID", "LastName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                repository.addCourse(course);
                return RedirectToAction("Index");
            }

            return View(course);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repository.getCourse(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title")] Course course)
        {
            if (ModelState.IsValid)
            {
                repository.editCourse(course);
                
                return RedirectToAction("Index");
            }
            return View(course);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repository.getCourse(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = repository.getCourse(id);
            repository.deleteCourse(course);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repository.dispose(disposing);
            base.Dispose(disposing);
        }
    }
}
