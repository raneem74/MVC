using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TraineesApp.Models
{
    public class Enrollment
    {
        
        [Column(Order = 0)]
        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }
        public virtual Trainee Trainee { get; set; }

        
        [Column(Order = 1)]
        [ForeignKey("Course")]
        public virtual int CourseID { get; set; }
        public Course Course { get; set; }

        [Required]
        public DateTime EnrolledDate { get; set; }
    }
}
