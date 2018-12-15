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
    public class RepositoryTest
    {
        [TestMethod]
        public void getStudentTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            int id = 1;

            var student = schoolRepository.getStudent(id);

            Assert.IsNotNull(student);
            Assert.AreEqual(student.ID, id);
        }
        [TestMethod]
        public void getInstructorTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            int id = 1;

            var instructor = schoolRepository.getInstructor(id);

            Assert.IsNotNull(instructor);
            Assert.AreEqual(instructor.ID, id);
        }
        [TestMethod]
        public void getEnrollmentTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            int id = 1;

            var enrollment = schoolRepository.getEnrollment(id);

            Assert.IsNotNull(enrollment);
            Assert.AreEqual(enrollment.EnrollmentID, id);
        }
        [TestMethod]
        public void getCourseTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            int id = SchoolInitializer.courses[0].ID;

            var course = schoolRepository.getCourse(id);

            Assert.IsNotNull(course);
            Assert.AreEqual(course.ID, id);
        }

        [TestMethod]
        public void getStudentsTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            var students = schoolRepository.getStudents().ToList();
            var Example = SchoolInitializer.students;

            Assert.IsNotNull(students);
            Assert.IsTrue(students[0].Equals(Example[0]));
        }
        [TestMethod]
        public void getInstructorsTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            var instructors = schoolRepository.getInstructors().ToList();
            var Example = SchoolInitializer.instructors;

            Assert.IsNotNull(instructors);
            Assert.IsTrue(instructors[0].Equals(instructors[0]));
        }
        [TestMethod]
        public void getEnrollmentsTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            var enrollments = schoolRepository.getEnrollments().ToList();
            var Example = SchoolInitializer.enrollments;

            Assert.IsNotNull(enrollments);
            Assert.IsTrue(enrollments[0].Equals(Example[0]));
        }
        [TestMethod]
        public void getCoursesTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            var courses = schoolRepository.getCourses().ToList();
            var Example = SchoolInitializer.courses;
            bool test = false;

            if (courses.Count==Example.Count)
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[0].Equals(Example[i]))
                    {
                        test = true;
                    }
                }


            }

            Assert.IsNotNull(courses);
            Assert.IsTrue(test);
        }
        [TestMethod]
        public void createCourseTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            int count = SchoolInitializer.courses.Count;

            var newCourse = new Course { ID = 1060, Title = "Programming", InstructorID = 1 };

            schoolRepository.addCourse(newCourse);
            var courses=schoolRepository.getCourses().ToList();

            Assert.AreEqual(count + 1, courses.Count);
        }

        [TestMethod]
        public void createEnrollmentTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            int count = SchoolInitializer.enrollments.Count;

            var newEnrollment = new Enrollment { StudentID = 1, CourseID = 1050, Grade = 6, date = DateTime.Parse("2018-5-3") };

            schoolRepository.addEnrollment(newEnrollment);
            var courses = schoolRepository.getEnrollments().ToList();

            Assert.AreEqual(count + 1, courses.Count);
        }
        [TestMethod]
        public void editCourseTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            var courseToEdit = schoolRepository.getCourse(1050);

            int id = 1;
            String name = "Programming1";

            courseToEdit.ID = id;
            courseToEdit.Title = name;

            Assert.AreEqual(courseToEdit.ID, id);
            Assert.AreEqual(courseToEdit.Title, name);
        }
        [TestMethod]
        public void editEnrollmentTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            var enrollmentToEdit = schoolRepository.getEnrollment(1);

            int courseID = 1;
            int studentID = 1;

            enrollmentToEdit.CourseID = courseID;
            enrollmentToEdit.StudentID = studentID;

            Assert.AreEqual(enrollmentToEdit.CourseID, courseID);
            Assert.AreEqual(enrollmentToEdit.StudentID, studentID);
        }
        [TestMethod]
        public void deleteStudentTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            var studentToBeDeleted = schoolRepository.getStudent(1);

            schoolRepository.deleteStudent(studentToBeDeleted);

            var isStudentDeleted = schoolRepository.getStudent(studentToBeDeleted.ID);

            Assert.IsNull(isStudentDeleted);
        }
        [TestMethod]
        public void deleteCourseTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            var courseToBeDeleted = schoolRepository.getCourse(SchoolInitializer.courses[0].ID);

            schoolRepository.deleteCourse(courseToBeDeleted);

            var isCourseDeleted = schoolRepository.getStudent(courseToBeDeleted.ID);

            Assert.IsNull(isCourseDeleted);
        }
        [TestMethod]
        public void deleteEnrollmentTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            var enrollmentToBeDeleted = schoolRepository.getEnrollment(1);

            schoolRepository.deleteEnrollment(enrollmentToBeDeleted);

            var isEnrollmentDeleted = schoolRepository.getEnrollment(enrollmentToBeDeleted.EnrollmentID);

            Assert.IsNull(isEnrollmentDeleted);
        }
        [TestMethod]
        public void passedCourseTest()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            var studentToCheck = schoolRepository.getStudent(1);
            var exampleToCheck = SchoolInitializer.students[0];

            var studentToCheckPassed = schoolRepository.passedCourse(studentToCheck);
            var exampleToCheckPassed = schoolRepository.passedCourse(exampleToCheck);

            Assert.IsTrue(studentToCheck.Equals(exampleToCheck));
            Assert.AreEqual(studentToCheckPassed.Count(), studentToCheckPassed.Count());
        }
        [TestMethod]
        public void checkIfStudenCanEnroll()
        {
            SchoolContext co = new SchoolContext();
            co.Database.Delete();

            Database.SetInitializer(new SchoolInitializer());

            SchoolRepository schoolRepository = new SchoolRepository(co);

            int studentID = 1;
            int courseID = 2021;
            int year = 2018;
            Students student=null;
            Course course=null;

            bool result = schoolRepository.checkIfStudenCanEnroll(studentID, courseID, year);

            foreach (var item in SchoolInitializer.students)
            {
                if (item.ID==studentID)
                {
                    student = item;
                }
            }
            foreach (var item in SchoolInitializer.courses)
            {
                if (item.ID == courseID)
                {
                    course = item;
                }
            }
            bool example = schoolRepository.checkIfStudenCanEnroll(student.ID, course.ID, 2018);

            Assert.AreEqual(result, example);

        }
    }
}
