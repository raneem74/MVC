using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TraineesApp.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Topic { get; set; }

        [Required]
        public int Grade { get; set; }

        // Navigation properties for the Enrollment class
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
