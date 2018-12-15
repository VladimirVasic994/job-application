using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public String Title { get; set; }
        public int InstructorID { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual IEnumerable<Enrollment> Enrollments { get; set; }
    }
}