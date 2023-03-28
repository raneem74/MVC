using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineesApp.DBServices_Repo_;
using TraineesApp.Models;

namespace TraineesApp.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        IDBRepo<Course> courseRepo { get; }
        public CourseController(IDBRepo<Course> crRepo)
        {
            courseRepo = crRepo;
        }

        // GET: TraineeController
        public ActionResult Index()
        {
            return View(courseRepo.GetAll());
        }

        // GET: TraineeController/Details/5
        public ActionResult Details(int id)
        {
            return View(courseRepo.GetById(id));
        }

        // GET: TraineeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course newCourse)
        {
            try
            {
                courseRepo.Add(newCourse);
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
            return View(courseRepo.GetById(id));
        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Course UpdatedCourse)
        {
            try
            {
                courseRepo.Update(id, UpdatedCourse);
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
            return View(courseRepo.GetById(id));
        }

        // POST: TraineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                courseRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
