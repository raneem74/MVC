using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineesApp.DBServices_Repo_;
using TraineesApp.Models;

namespace TraineesApp.Controllers
{
    [Authorize]
    public class TrackController : Controller
    {
        IDBRepo<Track> trackRepo { get; }
        public TrackController(IDBRepo<Track> trRepo)
        {
            trackRepo = trRepo;
        }

        // GET: TraineeController
        public ActionResult Index()
        {
            return View(trackRepo.GetAll());
        }

        // GET: TraineeController/Details/5
        public ActionResult Details(int id)
        {
            return View(trackRepo.GetById(id));
        }

        // GET: TraineeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Track newTrack)
        {
            try
            {
                trackRepo.Add(newTrack);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(trackRepo.GetById(id));
        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Track UpdatedTrack)
        {
            try
            {
                trackRepo.Update(id, UpdatedTrack);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(trackRepo.GetById(id));
        }

        // POST: TraineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                trackRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
