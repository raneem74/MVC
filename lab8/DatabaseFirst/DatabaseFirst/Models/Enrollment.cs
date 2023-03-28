using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class Enrollment
    {
        public int TraineeId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
