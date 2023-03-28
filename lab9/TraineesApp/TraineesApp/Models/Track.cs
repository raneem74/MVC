using System.ComponentModel.DataAnnotations;

namespace TraineesApp.Models
{
    public class Track
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        // Navigation property for the Trainee class
        public virtual ICollection<Trainee> Trainees { get; set; }
    }
}
