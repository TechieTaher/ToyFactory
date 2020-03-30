using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyFactory.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Address = new HashSet<Address>();
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }
        public long PhoneNo { get; set; }
        [Required]
        [StringLength(100)]
        public string EmaiId { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Address> Address { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
