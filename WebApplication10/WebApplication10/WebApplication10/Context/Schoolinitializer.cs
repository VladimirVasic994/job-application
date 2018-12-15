using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication10.Models;
using WebApplication10.Context;

namespace WebApplication10.Context
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        public static List<Students> students;
        public static List<Instructor> instructors;
        public static List<Course> courses;
        public static List<Enrollment> enrollments;

        public SchoolInitializer()
        {
            students = new List<Students>
            {
            new Students{FirstName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-2-2")},
            new Students{FirstName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-2-2")},
            new Students{FirstName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-2-2")},
            new Students{FirstName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-1-2")},
            new Students{FirstName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-3-5")},
            new Students{FirstName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-2-4")},
            new Students{FirstName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-1-4")},
            new Students{FirstName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-6-2")}
            };
            instructors = new List<Instructor>
            {
            new Instructor{FirstName="Dejan",LastName="Zvecanovic"},
            new Instructor{FirstName="Marko",LastName="Zekic"},
            new Instructor{FirstName="Mladen",LastName="Stefanovic"},
            };
            courses = new List<Course>
            {
            new Course{ID=1050,Title="Chemistry",InstructorID=1},
            new Course{ID=4022,Title="Microeconomics",InstructorID=2},
            new Course{ID=4041,Title="Macroeconomics",InstructorID=2},
            new Course{ID=1045,Title="Calculus" ,InstructorID=2},
            new Course{ID=3141,Title="Trigonometry",InstructorID=1},
            new Course{ID=2021,Title="Composition",InstructorID=1},
            new Course{ID=2042,Title="Literature",InstructorID=1}
            };
            enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=5,date=DateTime.Parse("2018-5-3")},
            new Enrollment{StudentID=1,CourseID=2021,Grade=6,date=DateTime.Parse("2018-2-13")},
            new Enrollment{StudentID=1,CourseID=4022,Grade=7,date=DateTime.Parse("2018-2-13")},
            new Enrollment{StudentID=2,CourseID=1050,Grade=8,date=DateTime.Parse("2018-2-13")},
            new Enrollment{StudentID=2,CourseID=4022,Grade=9,date=DateTime.Parse("2018-2-13")},
            new Enrollment{StudentID=2,CourseID=1050,Grade=10,date=DateTime.Parse("2018-2-13")},
            new Enrollment{StudentID=3,CourseID=4022,date=DateTime.Parse("2018-5-3")},
            new Enrollment{StudentID=4,CourseID=1050,date=DateTime.Parse("2018-5-3")},
            new Enrollment{StudentID=4,CourseID=2021,Grade=8,date=DateTime.Parse("2018-5-3")},
            new Enrollment{StudentID=5,CourseID=1050,Grade=7,date=DateTime.Parse("2018-5-3")},
            new Enrollment{StudentID=6,CourseID=3141,date=DateTime.Parse("2018-5-3")},
            new Enrollment{StudentID=7,CourseID=1050,Grade=6,date=DateTime.Parse("2018-5-3")},
            };
        }

        protected override void Seed(SchoolContext context)
        {
           

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
           
            instructors.ForEach(s => context.Instructors.Add(s));
            context.SaveChanges();
           
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();

            
        }
    }
}