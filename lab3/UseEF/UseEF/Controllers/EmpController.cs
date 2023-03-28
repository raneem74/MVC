using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UseEF.Models;

namespace UseEF.Controllers
{
    public class EmpController : Controller
    {
        EMPLOYEESEntities context = new EMPLOYEESEntities();
        // GET: Emp
        public ActionResult Index()
        {
            ViewBag.deptList = context.Depts.ToList();

            return View(context.Emps.ToList());
        }

        // GET: Emp/Details/5
        public ActionResult Details(int id)
        {
            Emp e = context.Emps.Find(id);

            return View(e);
        }

        // GET: Emp/Create
        public ActionResult Create()
        {
            ViewBag.deptList = context.Depts.ToList();
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Emp e = new Emp();
                e.EmpLname = collection["EmpLname"];
                e.EmpFname = collection["EmpFname"];
                e.EmpSalary = double.Parse(collection["EmpSalary"]);
                e.EmpHDate = DateTime.Parse(collection["EmpHDate"]);
                e.dID = int.Parse(collection["dID"]);
                e.CtyID = int.Parse(collection["CtyID"]);

                context.Emps.Add(e);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            Emp e = context.Emps.Find(id);
            ViewBag.deptList = context.Depts.ToList();
            return View(e);
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Emp e = context.Emps.Find(id);
                e.EmpLname = collection["EmpLname"];
                e.EmpFname = collection["EmpFname"];
                e.EmpSalary = double.Parse(collection["EmpSalary"]);
                e.EmpHDate = DateTime.Parse(collection["EmpHDate"]);
                e.dID = int.Parse(collection["dID"]);
                e.CtyID = int.Parse(collection["CtyID"]);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
           
            return View();
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Emp e = context.Emps.Find(id);
                context.Emps.Remove(e);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Filter(int did, FormCollection collection)
        {
            try
            {
                //Emp e = context.Emps.Find(id);
                //context.Emps.Remove(e);
                //context.SaveChanges();
                //return RedirectToAction("Index");
                List<Emp> elist = context.Emps.Where(e => e.dID  == did).ToList();
                return View(elist);
            }
            catch
            {
                return View();
            }
        }
    }
}
