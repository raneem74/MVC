using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Area.Areas.HR.Data
{
    public class EmployeeList : List<Employee>
    {

        public static EmployeeList EList = new EmployeeList()
    {
        new Employee()
        {
            ID = 1,
            Name = "John Smith",
            Username = "jsmith",
            Password = "password",
            Gender = GenderEnum.Male,
            Salary = 50000.00,
            joinDate = new DateTime(2020, 1, 1),
            email = "jsmith@example.com",
            phoneNum = "555-555-5555"
        },
                new Employee()
                {
                    ID = 2,
                    Name = "Jane Doe",
                    Username = "jdoe",
                    Password = "password",
                    Gender = GenderEnum.Female,
                    Salary = 60000.00,
                    joinDate = new DateTime(2019, 6, 1),
                    email = "jdoe@example.com",
                    phoneNum = "555-555-5555"
                },
                new Employee()
                {
                    ID = 3,
                    Name = "Bob Johnson",
                    Username = "bjohnson",
                    Password = "password",
                    Gender = GenderEnum.Male,
                    Salary = 55000.00,
                    joinDate = new DateTime(2021, 3, 1),
                    email = "bjohnson@example.com",
                    phoneNum = "555-555-5555"
                },
                new Employee()
                {
                    ID = 4,
                    Name = "Samantha Lee",
                    Username = "slee",
                    Password = "password",
                    Gender = GenderEnum.Female,
                    Salary = 65000.00,
                    joinDate = new DateTime(2022, 1, 1),
                    email = "slee@example.com",
                    phoneNum = "555-555-5555"
                },
                new Employee()
                {
                    ID = 5,
                    Name = "Michael Nguyen",
                    Username = "mnguyen",
                    Password = "password",
                    Gender = GenderEnum.Female,
                    Salary = 45000.00,
                    joinDate = new DateTime(2020, 8, 1),
                    email = "mnguyen@example.com",
                    phoneNum = "555-555-5555"
                }

            };


    }  
}