using Car_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Linq;

namespace Car_Core.Controllers
{
    public class CarController : Controller
    {
        // GET: CarController
        public ActionResult Index()
        {
            return View(CarList.cList);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            Car c = CarList.cList.FirstOrDefault(i=>i.Num == id);
            return View(c);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car c)
        {
            try
            {
                Car car = new Car { Num = c.Num ,Model = c.Model , Color = c.Color  , Manfacture = c.Manfacture  };  
                CarList.cList.Add(car);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            Car car = CarList.cList.FirstOrDefault(i => i.Num == id);

            return View(car);
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car c)
        {
            try
            {
                Car car = CarList.cList.FirstOrDefault(i => i.Num == id);
                car.Num= c.Num;
                car.Model = c.Model;
                car.Manfacture = c.Manfacture;
                car.Color = c.Color;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            Car car = CarList.cList.FirstOrDefault(i => i.Num == id);

            return View(car);
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Car car = CarList.cList.FirstOrDefault(i => i.Num == id);
                CarList.cList.Remove(car);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
