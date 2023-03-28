using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Area.Areas.HR.Data
{
    public enum GenderEnum
    {
        Male,
        Female
    }

    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        //[EnumDataType(typeof(GenderEnum))]
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, 20000, ErrorMessage = "Salary must be a positive number less than 20000")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Join date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime joinDate { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        public string phoneNum { get; set; }
    }
}