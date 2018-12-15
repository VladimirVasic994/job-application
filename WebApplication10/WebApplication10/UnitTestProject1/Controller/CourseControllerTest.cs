using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using WebApplication10.Context;
using WebApplication10.Controllers;
using WebApplication10;
using WebApplication10.Models;

namespace UnitTestProject1.Controller
{
    [TestClass]
    public class CourseControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //Asembly
            CoursesController coursesController = new CoursesController();

            //Act
            ViewResult result = coursesController.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Details()
        {

            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            CoursesController coursesController = new CoursesController();

            ViewResult result = coursesController.Details(1050) as ViewResult;

            var model = (Course)result.ViewData.Model;

            Assert.IsTrue(model.Equals(SchoolInitializer.courses[0]));
        }
        [TestMethod]
        public void Create()
        {

            CoursesController coursesController = new CoursesController();

            ViewResult result = coursesController.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

    }
}
