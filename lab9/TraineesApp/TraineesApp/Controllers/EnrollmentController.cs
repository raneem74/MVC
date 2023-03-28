using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineesApp.DBServices_Repo_;
using TraineesApp.Models;

namespace TraineesApp.Controllers
{
    [Authorize]
    public class EnrollmentController : Controller
    {
        IDBManyRepo<Enrollment> enrollmentRepo { get; }
        public IDBRepo<Trainee> TraineeRepo { get; }
        public IDBRepo<Course> CourseRepo { get; }

        public EnrollmentController(IDBManyRepo<Enrollment> enRepo,IDBRepo<Trainee> traineeRepo,IDBRepo<Course>courseRepo)
        {
            enrollmentRepo = enRepo;
            TraineeRepo = traineeRepo;
            CourseRepo = courseRepo;
        }

        // GET: TraineeController
        public ActionResult Index()
        {
            return View(enrollmentRepo.GetAll());
        }

        // GET: TraineeController/Details/5
        public ActionResult Details(int traineeId, int courseId)
        {
            return View(enrollmentRepo.GetById(traineeId,courseId));
        }

        // GET: TraineeController/Create
        public ActionResult Create()
        {
            ViewBag.trainees = TraineeRepo.GetAll();
            ViewBag.courses = CourseRepo.GetAll();

            return View();
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Enrollment newEnrollment)
        {
            try
            {
                enrollmentRepo.Add(newEnrollment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController/Edit/5
        public ActionResult Edit(int traineeId, int courseId)
        {
            return View(enrollmentRepo.GetById(traineeId,courseId));
        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int traineeId, int courseId, Enrollment UpdatedEnrollment)
        {
            try
            {
                enrollmentRepo.Update(traineeId,courseId,UpdatedEnrollment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController/Delete/5
        public ActionResult Delete(int traineeId, int courseId)
        {
            return View(enrollmentRepo.GetById(traineeId,courseId));
        }

        // POST: TraineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int traineeId, int courseId, IFormCollection collection)
        {
            try
            {
                enrollmentRepo.Delete(traineeId,courseId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
