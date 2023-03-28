using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Topic { get; set; }

        public int CourseGrade { get; set; }

        // Foreign key property
        public int StudentID { get; set; }

        // Navigation property
        public Student Student { get; set; }
    }
}
