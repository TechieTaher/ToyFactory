using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyFactory.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int AddressId { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressLine1 { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(50)]
        public string Locality { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        public int PostalCode { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Models.Customers.Address))]
        public virtual Customers Customer { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
