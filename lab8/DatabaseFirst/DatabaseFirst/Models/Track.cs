using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class Track
    {
        public Track()
        {
            Trainees = new HashSet<Trainee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Trainee> Trainees { get; set; }
    }
}
