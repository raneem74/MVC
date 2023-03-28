using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TraineesApp.Models
{
    public enum Gender { male , female}
    public class Trainee
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Name Must be only characters")]

        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string MobileNo { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        // Navigation properties for the Track and Enrollment classes
        public virtual int TrackID { get; set; }
        public virtual Track Track { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
