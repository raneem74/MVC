using Microsoft.EntityFrameworkCore;

namespace TraineesApp.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options):base(options) 
        {
        }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.CourseID, e.TraineeID });
        }
    }
}
