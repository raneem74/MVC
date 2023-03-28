using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client.Models
{
    
    public class CustomerList
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer() { ID = 1, Name = "John Smith", Gender = Gender.Male, Email = "johnsmith@example.com", PhoneNum = "+1-555-1234" },
            new Customer() { ID = 2, Name = "Sarah Johnson", Gender = Gender.Female, Email = "sarahj@example.com", PhoneNum = "+1-555-5678" },
            new Customer() { ID = 3, Name = "Alex Rodriguez", Gender = Gender.Male, Email = "arod@example.com", PhoneNum = "+1-555-9012" },
            new Customer() { ID = 4, Name = "Emily Brown", Gender = Gender.Female, Email = "emilyb@example.com", PhoneNum = "+1-555-3456" },
            new Customer() { ID = 5, Name = "David Lee", Gender = Gender.Male, Email = "davidl@example.com", PhoneNum = "+1-555-7890" }
        };
    }
}