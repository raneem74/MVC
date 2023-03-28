using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineesApp.DBServices_Repo_;
using TraineesApp.Models;

namespace TraineesApp.Controllers
{
    [Authorize]
    public class TraineeController : Controller
    {
        IDBRepo<Trainee> traineeRepo { get; }
        public IDBRepo<Track> trackRepo { get; }

        public TraineeController(IDBRepo<Trainee> trRepo , IDBRepo<Track> trckRepo)
        {
            traineeRepo = trRepo;
            trackRepo = trckRepo;
        }
        
        // GET: TraineeController
        public ActionResult Index()
        {
            //ViewBag.tracks = trackRepo.GetAll();
            return View(traineeRepo.GetAll());
        }

        // GET: TraineeController/Details/5
        public ActionResult Details(int id)
        {
            return View(traineeRepo.GetById(id));
        }

        // GET: TraineeController/Create
        public ActionResult Create()
        {
            ViewBag.tracks = trackRepo.GetAll();
            return View();
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainee newTrainee)
        {
            try
            {
                traineeRepo.Add(newTrainee);
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
            ViewBag.tracks = trackRepo.GetAll();
            return View(traineeRepo.GetById(id));
        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Trainee UpdatedTrainee)
        {
            try
            {
                traineeRepo.Update(id, UpdatedTrainee);
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
            return View(traineeRepo.GetById(id));
        }

        // POST: TraineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                traineeRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
