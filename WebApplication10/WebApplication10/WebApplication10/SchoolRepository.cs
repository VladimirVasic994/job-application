using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication10.Context;
using WebApplication10.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace WebApplication10
{
    public class SchoolRepository
    {
        private SchoolContext context;

        public SchoolRepository(SchoolContext context)
        {
            this.context = context;
        }

        public bool checkIfStudenCanEnroll(int studentId, int courseId, int forYear)
        {
            List<Enrollment> pastEnrollments = context.Enrollments.Include(x => x.Course).ToList();

            if (pastEnrollments.Where(e => e.StudentID == studentId
                    && e.CourseID == courseId
                    && e.date.Year == forYear).Count() >= 5)
            {
                return false;
            }
            return true;
        }

        public Students getStudent(int? id)
        {
            return context.Students.Find(id);
        }

        public Course getCourse(int? id)
        {
            return context.Courses.Find(id);
        }

        public Instructor getInstructor(int? id)
        {
            return context.Instructors.Find(id);
        }

        public IEnumerable<Instructor> getInstructors()
        {
           return context.Instructors.ToList();
        }

        public IEnumerable<Enrollment> passedCourse(Students student)
        {
            return context.Enrollments.Where(x => x.StudentID == student.ID && x.Grade > 5).Include(x => x.Course);
        }

        public Enrollment getEnrollment(int? id)
        {
            return context.Enrollments.Find(id);
        }

        public IEnumerable<Enrollment> getEnrollments()
        {
            return context.Enrollments.ToList();
        }

        public IEnumerable<Students> getStudents()
        {
            return context.Students.ToList();
        }

        public void addCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public IEnumerable<Course> getCourses()
        {
            return context.Courses.ToList();
        }

        public void deleteStudent(Students students)
        {
            context.Students.Remove(students);
            context.SaveChanges();
        }

        public IEnumerable<Course> getCoursesForInstructors(int iD)
        {
            return context.Courses.Where(x => x.InstructorID == iD);
        }

        public IEnumerable<Enrollment> getStudentsThatPassed(IEnumerable<Course> courses , DateTime startDate, DateTime endDate)
        {
             return context.Enrollments.Where(y => courses.Contains(y.Course)
             && y.date >= startDate
             && y.date <= endDate
             && y.Grade > 5).ToList();
        }

        public void addEnrollment(Enrollment enrollment)
        {
            context.Enrollments.Add(enrollment);
            context.SaveChanges();
        }

        public void editCourse(Course course)
        {
            context.Entry(course).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void editEnrollment(Enrollment enrollment)
        {
            context.Entry(enrollment).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void deleteEnrollment(Enrollment enrollment)
        {
            context.Enrollments.Remove(enrollment);
            context.SaveChanges();
        }

        public void dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            
        }

        public void deleteCourse(Course course)
        {
            context.Courses.Remove(course);
            context.SaveChanges();
        }
    }
}