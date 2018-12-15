using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public DateTime date { get; set; }
        public int Grade { get; set; }
        

        public virtual Course Course { get; set; }
        public virtual Students Student { get; set; }
        public override bool Equals(object obj)
        {
            var item = obj as Enrollment;

            if (item == null)
            {
                return false;
            }

            if (CourseID.Equals(item.CourseID) && StudentID.Equals(item.StudentID) && date.Equals(item.date)) 
            {
                return true;
            }

            return false;
        }
    }
}