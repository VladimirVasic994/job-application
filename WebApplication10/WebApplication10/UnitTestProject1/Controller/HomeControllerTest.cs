using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication10.Context;
using WebApplication10.Controllers;
using WebApplication10;

namespace UnitTestProject1.Controller
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();


            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index1()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            var acctalStudents=co.Students.ToList();
            CollectionAssert.AreEqual(acctalStudents, SchoolInitializer.students);

            Assert.IsTrue(acctalStudents[0].Equals(SchoolInitializer.students[0]));

            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            SchoolRepository repository = new SchoolRepository(co);

            repository.checkIfStudenCanEnroll(1, 1, 1);

            Assert.IsNotNull(result);
        }
    }
}
