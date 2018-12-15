using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class Students
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual IEnumerable<Enrollment> Enrollments { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as Students;

            if (item == null)
            {
                return false;
            }

            if(FirstName.Equals(item.FirstName))
            {
                return true;
            }

            return false;
        }
    }
}