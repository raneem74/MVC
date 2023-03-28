using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public enum Gender { female , male}
    public partial class Trainee
    {
        public Trainee()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public DateTime Birthdate { get; set; }
        public int TrackId { get; set; }

        public virtual Track Track { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
