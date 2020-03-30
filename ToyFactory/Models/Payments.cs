using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyFactory.Models
{
    public partial class Payments
    {
        public Payments()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int PaymentId { get; set; }
        public int PaymentType { get; set; }
        public int Amount { get; set; }

        [InverseProperty("Payment")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
