using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public enum Gender { Female , Male }
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        [startWithUpper]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNum { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}