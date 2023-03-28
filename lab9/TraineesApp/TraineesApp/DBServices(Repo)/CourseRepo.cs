using Microsoft.EntityFrameworkCore;
using TraineesApp.Models;

namespace TraineesApp.DBServices_Repo_
{
    public class CourseRepo : IDBRepo<Course>
    {
        public MainContext Context { get; }

        //request service of type mainDbContext to be injected in Ctor
        public CourseRepo(MainContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Course course)
        {
            Context.Courses.Add(course);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var courseToDelete = Context.Courses.Find(id);
            if (courseToDelete != null)
            {
                Context.Courses.Remove(courseToDelete);
                Context.SaveChanges();
            }
        }

        public List<Course> GetAll()
        {
            return Context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return Context.Courses.Find(id);
        }

        public void Update(int id, Course updatedCourse)
        {
            var existingCourse = Context.Courses.Find(id);

            if (existingCourse != null)
            {
                existingCourse.Topic = updatedCourse.Topic;
                existingCourse.Grade = updatedCourse.Grade;

                Context.SaveChanges();
            }
        }
    }
}
