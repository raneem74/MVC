using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Topic { get; set; }
        public int Grade { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
