using Microsoft.EntityFrameworkCore;
using TraineesApp.Models;

namespace TraineesApp.DBServices_Repo_
{
    public class TrackRepo : IDBRepo<Track>
    {
        public MainContext Context { get; }

        //request service of type mainDbContext to be injected in Ctor
        public TrackRepo(MainContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Track track)
        {
            Context.Tracks.Add(track);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var trackToDelete = Context.Tracks.Find(id);
            if (trackToDelete != null)
            {
                Context.Tracks.Remove(trackToDelete);
                Context.SaveChanges();
            }
        }

        public List<Track> GetAll()
        {
            return Context.Tracks.ToList();
        }

        public Track GetById(int id)
        {
            return Context.Tracks.Find(id);
        }

        public void Update(int id, Track updatedTrack)
        {
            var existingTrack = Context.Tracks.Find(id);

            if (existingTrack != null)
            {
                existingTrack.Name = updatedTrack.Name;
                existingTrack.Description = updatedTrack.Description;

                Context.SaveChanges();
            }
        }
    }
}
