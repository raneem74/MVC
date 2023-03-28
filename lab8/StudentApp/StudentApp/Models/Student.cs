using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace StudentApp.Models
{
    public enum Gender { female , male}
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNum { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        // Navigation property
        public ICollection<Course> Courses { get; set; }
    }
}
