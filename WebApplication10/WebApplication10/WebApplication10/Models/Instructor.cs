using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        

        public virtual IEnumerable<Course> Courses { get; set; }
    }
}