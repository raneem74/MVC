using Microsoft.EntityFrameworkCore;
using TraineesApp.Models;

namespace TraineesApp.DBServices_Repo_
{
    public class TraineeReop : IDBRepo<Trainee>
    {
        public MainContext Context { get; }

        //request service of type mainDbContext to be injected in Ctor
        public TraineeReop(MainContext context)
        {
            Context = context;
        }
        public void Add(Trainee trainee)
        {
            Context.Trainees.Add(trainee);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.Remove(Context.Trainees.Include(t => t.Track).FirstOrDefault(t => t.ID == id));
            Context.SaveChanges();
        }

        public List<Trainee> GetAll()
        {
            return Context.Trainees.Include(t=>t.Track).ToList();
        }

        public Trainee GetById(int id)
        {
            return Context.Trainees.Include(t => t.Track).FirstOrDefault(t => t.ID == id);
        }

        public void Update(int id, Trainee updatedTrainee)
        {
            var existingTrainee = Context.Trainees.Find(id);

            if (existingTrainee != null)
            {
                existingTrainee.Name = updatedTrainee.Name;
                existingTrainee.Gender = updatedTrainee.Gender;
                existingTrainee.Email = updatedTrainee.Email;
                existingTrainee.MobileNo = updatedTrainee.MobileNo;
                existingTrainee.Birthdate = updatedTrainee.Birthdate;
                existingTrainee.TrackID = updatedTrainee.TrackID;

                Context.SaveChanges();
            }
        }
    }
}
