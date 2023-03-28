using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DisplayForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowDetails(int id, string name , string image)
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            ViewBag.Image = image;
            return View();

        }
    }
}