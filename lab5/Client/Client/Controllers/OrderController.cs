using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    [HandleError(View = "OrderError")]
    public class OrderController : Controller
    {
        
        // GET: Order
        public ActionResult Index()
        {
            ViewBag.customers = CustomerList.customers;
            return View(OrderList.orders);
        }


        [OrderExceptionHandler]
        [HttpPost]
        public ActionResult Index(int ID)
        {
            if (ModelState.IsValid)
            {
                ViewBag.customers = CustomerList.customers;
                if (OrderList.orders.Where(o => o.CustID == ID).Count() == 0)
                    throw new Exception();
                return View(OrderList.orders.Where(o => o.CustID == ID));

            }
            else
            {
                return View();
            }

            

        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View(OrderList.orders.FirstOrDefault(i => i.ID == id));
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order or = new Order();
                    or.Date = order.Date;
                    or.TotalPrice = order.TotalPrice;
                    or.CustID = order.CustID;
                    OrderList.orders.Add(or);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View(OrderList.orders.FirstOrDefault(i => i.ID == id));
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order or = OrderList.orders.FirstOrDefault(i => i.ID == id);
                    or.Date = order.Date;
                    or.TotalPrice = order.TotalPrice;
                    or.CustID = order.CustID;
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }

            }
            else
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View(OrderList.orders.FirstOrDefault(i => i.ID == id));
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Order or = OrderList.orders.FirstOrDefault(i => i.ID == id);
                OrderList.orders.Remove(or);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
