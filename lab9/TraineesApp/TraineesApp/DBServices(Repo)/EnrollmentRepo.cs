using Microsoft.EntityFrameworkCore;
using TraineesApp.Models;

namespace TraineesApp.DBServices_Repo_
{
    public class EnrollmentRepo : IDBManyRepo<Enrollment>
    {
        public MainContext Context { get; }

        //request service of type mainDbContext to be injected in Ctor
        public EnrollmentRepo(MainContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Enrollment enrollment)
        {
            Context.Enrollments.Add(enrollment);
            Context.SaveChanges();
        }

        public void Delete(int traineeId  , int courseId)
        {
            var enrollmentToDelete = Context.Enrollments.FirstOrDefault(e => e.TraineeID == traineeId && e.CourseID == courseId);
            if (enrollmentToDelete != null)
            {
                Context.Enrollments.Remove(enrollmentToDelete);
                Context.SaveChanges();
            }
        }

        public List<Enrollment> GetAll()
        {
            return Context.Enrollments.Include(i=> i.Trainee).Include(i=>i.Course).ToList();
        }

        public Enrollment GetById(int traineeId, int courseId)
        {
            return Context.Enrollments.Include(i => i.Trainee).Include(i => i.Course).FirstOrDefault(e => e.TraineeID == traineeId && e.CourseID == courseId) ;
        }

        public void Update(int traineeId, int courseId, Enrollment updatedEnrollment)
        {
            var existingEnrollment = Context.Enrollments.FirstOrDefault(e => e.TraineeID == traineeId && e.CourseID == courseId); ;


            if (existingEnrollment != null)
            {
                existingEnrollment.EnrolledDate = updatedEnrollment.EnrolledDate;
                Context.SaveChanges();
            }
        }
    }
}
