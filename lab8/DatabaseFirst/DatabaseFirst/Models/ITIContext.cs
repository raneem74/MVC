using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseFirst.Models
{
    public partial class ITIContext : DbContext
    {
        public ITIContext()
        {
        }

        public ITIContext(DbContextOptions<ITIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=ITI;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.TraineeId });

                entity.HasIndex(e => e.TraineeId, "IX_Enrollments_TraineeID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.TraineeId).HasColumnName("TraineeID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.TraineeId);
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.HasIndex(e => e.TrackId, "IX_Trainees_TrackID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.MobileNo).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TrackId).HasColumnName("TrackID");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.Trainees)
                    .HasForeignKey(d => d.TrackId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
