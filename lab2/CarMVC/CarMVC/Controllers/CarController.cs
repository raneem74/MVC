using CarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllCars()
        {
            ViewBag.carList = CarList.cList;
            return View();
        }
        
        public ActionResult SelectCarById(int? id)
        {
            ViewBag.car = CarList.cList.FirstOrDefault(c => c.Num == id );
            return View();
        }
        public ActionResult CreateNewCar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNewCar(int num , string color , string model , string manfacture)
        {
            Car car = new Car() { Num = num, Color = color, Model = model, Manfacture = manfacture };
            CarList.cList.Add(car);
            return RedirectToAction("GetAllCars");
        }
        public ActionResult UpdateCar(int? id)
        {
            ViewBag.car = CarList.cList.FirstOrDefault(c => c.Num == id);
            return View();
        }
        [HttpPost]
        public ActionResult UpdateCar(int num, string color, string model, string manfacture)
        {
            Car car = CarList.cList.FirstOrDefault(c => c.Num==num);
            car.Color = color;
            car.Model = model;
            car.Manfacture = manfacture;
            return RedirectToAction("GetAllCars");
        }
        public ActionResult DeleteCar(int? id)
        {
            Car car = CarList.cList.FirstOrDefault(c => c.Num == id);
            CarList.cList.Remove(car);
            return RedirectToAction("GetAllCars");
        }




    }
}