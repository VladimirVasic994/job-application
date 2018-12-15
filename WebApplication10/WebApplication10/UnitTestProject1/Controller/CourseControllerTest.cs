using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using WebApplication10.Context;
using WebApplication10.Controllers;
using WebApplication10;

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


        }
    }
}
