using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    [RoutePrefix("Cutomers/Managing")]
    [HandleError(View = "cusomError")]
    public class CustomerController : Controller
    {
        [Route("error")]
        public ActionResult error()
        {
            int z = 0;
            int x = 5 / z;
            return View();
        }


        [Route("Index")]
        // GET: Customer
        public ActionResult Index()
        {
            return View(CustomerList.customers);
        }

        // GET: Customer/Details/5
        [Route("Details/{id:int}")]
        public ActionResult Details(int id)
        {
            return View(CustomerList.customers.FirstOrDefault(i => i.ID == id));
        }

        // GET: Customer/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Customer cus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customer newC = new Customer();

                    newC.Name = cus.Name;
                    newC.Email = cus.Email;
                    newC.PhoneNum = cus.PhoneNum;
                    newC.Gender = cus.Gender;

                    CustomerList.customers.Add(newC);


                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View();

        }

        [Route("Edit/{id:int}")]
        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(CustomerList.customers.FirstOrDefault(i => i.ID == id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [Route("Edit/{id:int}")]
        public ActionResult Edit(int id, Customer cus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Customer ucus = CustomerList.customers.FirstOrDefault(i => i.ID == id);
                    ucus.Name = cus.Name;
                    ucus.Email = cus.Email;
                    ucus.PhoneNum = cus.PhoneNum;
                    ucus.Gender = cus.Gender;

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return View() ;
            }
        }

        [Route("Delete/{id:int}")]
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(CustomerList.customers.FirstOrDefault(i => i.ID == id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [Route("Delete/{id:int}")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Customer del = CustomerList.customers.FirstOrDefault(i => i.ID == id);
                CustomerList.customers.Remove(del);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
