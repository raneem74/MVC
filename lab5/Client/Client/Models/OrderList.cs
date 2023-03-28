using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class OrderList
    {
        public static List<Order> orders = new List<Order>()
        {
            new Order() { ID = 1, Date = DateTime.Now, TotalPrice = 100.00m, CustID = 1, Customer=CustomerList.customers.FirstOrDefault(i=>i.ID == 1) },
            new Order() { ID = 2, Date = DateTime.Now, TotalPrice = 50.00m, CustID = 2, Customer=CustomerList.customers.FirstOrDefault(i=>i.ID == 2) },
            new Order() { ID = 3, Date = DateTime.Now, TotalPrice = 75.00m, CustID = 1, Customer=CustomerList.customers.FirstOrDefault(i=>i.ID == 1) },
            new Order() { ID = 4, Date = DateTime.Now, TotalPrice = 200.00m, CustID = 3, Customer=CustomerList.customers.FirstOrDefault(i=>i.ID == 3) },
            new Order() { ID = 5, Date = DateTime.Now, TotalPrice = 25.00m, CustID = 4, Customer=CustomerList.customers.FirstOrDefault(i=>i.ID == 4) }
        };
    }
}