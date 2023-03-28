using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }

        public Customer Customer { get; set; }
    }
}